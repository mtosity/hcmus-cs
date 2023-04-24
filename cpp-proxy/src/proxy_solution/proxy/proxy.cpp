// webtry.cpp : This file contains the 'main' function. Program execution begins and ends there.
//

#include "pch.h"
#include "framework.h"
#include "proxy.h"

#include <afxsock.h>
#include <thread>
#include <iostream>
#include <vector>
#include <fstream>
#include <string>
#include <direct.h>
#include <stdio.h>




#ifdef _DEBUG
#define new DEBUG_NEW
#endif


#define PORT "8888"
#define WEB_PORT "80"
#define block_response "HTTP/1.1 403 FORBIDDEN\r\nConnection: close\r\nContent-Type: text/html\r\n\r\n<html>\r\n<body>\r\Not found 404\r\n</body>\r\n</html>\r\n\r\n"
#define cache_max_size 100
#define BUF_MAX_SIZE 65000
using namespace std;
CWinApp theApp;

DWORD WINAPI client_listen(LPVOID lp);
int freeIndex();
bool right_request(char* request);
char* get_host(char* request);
bool isEmptyMem(char *s, int l);
vector<char*> read_black_list(string file_name);
vector<char*> black_list = read_black_list("blacklist.conf");
bool send_block_response(SOCKET client);

SOCKET createserverSocket(char* pcAddress, char* pcPort);
bool sendToSocket(const char* buff, SOCKET sockfd, int buff_length, string name_sock);
bool revThenSendBack(SOCKET Clientfd, SOCKET Serverfd, char* request, int index);
bool ImCaching(char * request, SOCKET cli, SOCKET serv, int index);
int have_cached(char *request);
char * get_date(char * response);
bool updateCacheDate(int index);
char * rebuilded_rq(int index, char *request);
char * get_etag(char * response);
void receiveCache(SOCKET Clientfd, SOCKET servefd, int index);
bool can_Cache(char *response);
bool revThenSendBack2(SOCKET Clientfd, SOCKET Serverfd, char* request); //Because the bits when reciving is too big so read 2000 then send 2000 bits
int recentCache = 0;
char *get_response_header(char *response);
struct CACHE {
	char host[100];
	char page[500];
	char datetime[100];
	char etag[100];
	CACHE() {
		memset(host, 0, 100);
		memset(page, 0, 500);
		memset(datetime, 0, 100);
		memset(etag, 0, 100);
		//do
		//{
		//	cached = (char *)malloc(BUF_MAX_SIZE);
		//} while (cached == NULL);
	}
};
CACHE* cache = new CACHE[cache_max_size];
vector<vector<char*>> data(cache_max_size);
//int indexOfCache = -1;
int main(int argc, char* argv[])
{
	int nRetCode = 0;

	HMODULE hModule = ::GetModuleHandle(nullptr);

	if (hModule != nullptr)
	{
		//Read all black list===========================================================================================================================================================
		
		// initialize MFC and print and error on failure
		if (!AfxWinInit(hModule, NULL, ::GetCommandLine(), 0))
		{
			// TODO: change error code to suit your needs
			_tprintf(_T("Fatal Error: MFC initialization failed\n"));
			nRetCode = 1;
		}
		else
		{
			//Create proxy socket================================================================================================================================================================
			AfxSocketInit();
			SOCKET proxy;
			proxy = socket(AF_INET, SOCK_STREAM, 0);   // create a socket
			if (proxy < 0) {
				fprintf(stderr, " SORRY! Cannot create a socket ! \n");
				return 1;
			}

			//Proxy Adress===========================================================================================================================================================================
			struct sockaddr_in serv_addr;
			memset(&serv_addr, 0, sizeof serv_addr);
			int  portno = atoi(PORT);           //define on the top
			serv_addr.sin_family = AF_INET;     // ip4 family 
			serv_addr.sin_addr.s_addr = INADDR_ANY;  // represents for localhost i.e 127.0.0.1 
			serv_addr.sin_port = htons(portno);

			//Bind and listen ================================================================================================================================================================
			int binded = ::bind(proxy, (struct sockaddr*) & serv_addr, sizeof(serv_addr));
			if (binded < 0) {
				fprintf(stderr, " Error on binding! \n");
				return 1;
			}
			listen(proxy, 1);  // can have maximum of 100 browser requests
			//Introduction==========================================================================================================================================================================
			std::cout << "listening... (8888)" << std::endl;
			std::cout << "first load will take a long time (block web: nhungtrangwebvietnam.com)" << std::endl;

			//Accept new client==========================================================================================================================================================================
			struct sockaddr cli_addr;
			int addr_len = sizeof(struct sockaddr);
			int newsock_request;
			while (1)
			{
				/* A browser request starts here */
				newsock_request = accept(proxy, &cli_addr, (socklen_t*)& addr_len);

				if (newsock_request < 0) {
					fprintf(stderr, " ERROR! On Accepting Request ! i.e requests limit crossed \n");
				}
				else if (newsock_request == INVALID_SOCKET || newsock_request == 0)
				{
					closesocket(newsock_request);
				}
				else
				{
					DWORD dwGET;
					HANDLE hGET;

					hGET = CreateThread(NULL, 0, client_listen, (LPVOID)newsock_request, 0, &dwGET);
				}
			}
			closesocket(proxy);
		}
		//Clean up ====================================================================================================================================================================================
		WSACleanup();
		for (int i = 0; i < black_list.size(); i++)
			free(black_list[i]);
	}
	else
	{
		// TODO: change error code to suit your needs
		_tprintf(_T("Fatal Error: GetModuleHandle failed\n"));
		nRetCode = 1;
	}


	return nRetCode;
}

DWORD WINAPI client_listen(LPVOID lp)
{
	//Recieve request================================================================================================================================================================
	SOCKET client = (SOCKET)lp;
	SOCKET server;
	char buf[5000];

	int MAX_BUFFER_SIZE = 5000;
	char* request_message = (char*)malloc(MAX_BUFFER_SIZE);  // Get message from URL
	if (request_message == NULL) {
		std::cout << " Error in memory allocation when creating request message !" << endl;
		return 0;
	}
	memset(request_message, 0, 5000);

	//if (cache.size() < 100)
	//	cache.push_back(new CACHE);
	int total_recieved_bits = 0;
	int recvd = 5000;
	while (strstr(request_message, "\r\n\r\n") == NULL) {  // determines end of request

		memset(buf, 0, recvd); //reset buf

		recvd = recv(client, buf, 5000 - 1, 0);

		if (recvd < 0) {
			cout << " Error while recieving, code: " << WSAGetLastError() << endl;
			return 0;

		}
		else if (recvd == 0) {
			break;
		}
		else {

			total_recieved_bits += recvd;
			buf[recvd] = '\0';

			/* if total message size greater than our string size,double the string size */
			if (total_recieved_bits > MAX_BUFFER_SIZE) {
				MAX_BUFFER_SIZE *= 2;
				request_message = (char*)realloc(request_message, MAX_BUFFER_SIZE);
				if (request_message == nullptr) {
					cout << " Error in memory re-allocation,  request_message!" << endl;
					return 0;
				}
			}

			strcat(request_message, buf);
		}
	}

	if (right_request(request_message))
	{
//		cout << request_message << endl;
		char* host = get_host(request_message);
		if (host != nullptr)
		{

			//Check black list ===================================================================================================================================================
			for (int i = 0; i < black_list.size(); i++)
			{
				cout << black_list[i] << endl;
				if (strcmp(host, black_list[i]) == 0)
				{
					if (send_block_response(client) == false)
						cout << " Can not send block response, code: " << WSAGetLastError() << endl;
					return 0;
				}
			}

			//Check need to cache, create dir ======================================================================================================================================================
			//Client and server communicate here ==================================================================================================================================
			server = createserverSocket(host, WEB_PORT); //Connect to server
			if (server < 0)
				return 0;

			int cached = -1;
			int index = freeIndex();

			if (cached = have_cached(request_message) < 0) {
				printf("cache : %d %s\n", index, cache[index].page);

				if (!sendToSocket(request_message, server, total_recieved_bits, "server")) //send request to the server
				{
					cout << " Can not finish to send to server, code: " << WSAGetLastError() << endl;
					return 0;
				}
				if (!revThenSendBack(client, server,request_message, index)) //recive from server and then send back to browser 
				{
					cout << " Can not finish to recv from server and send back, code: " << WSAGetLastError() << endl;
					return 0;
				}
				closesocket(server);
			}
			else{
				if (!sendToSocket(request_message, server, total_recieved_bits, "server")) //send request to the server
				{
					cout << " Can not finish to send to server, code: " << WSAGetLastError() << endl;
					return 0;
				}
				cout << "da cache " << cache[cached].page << endl;
				if (!revThenSendBack2(client, server, request_message)) //recive from server and then send back to browser 
				{
					cout << " Can not finish to recv from server and send back, code: " << WSAGetLastError() << endl;
					return 0;
				}
				closesocket(server);
			}
		}
		else
			cout << " Can not find host in request!" << endl;
	}
	free(request_message);
	closesocket(client);
	return 0;
}



char* get_host(char* request)
{
	int re_len = strlen(request);
	char* host = nullptr;

	char* starthost;
	starthost = strstr(request, "Host");
	int host_len = 0;
	if (starthost != nullptr)
	{
		starthost = starthost + strlen("Host: ");

		while (1)
		{
			if (starthost[host_len] == '\r') //End of host (because its the HTTP request so it dont have ":443")
				break;
			host_len++;
		}
		if (host_len > 0)
		{
			host = (char*)malloc(host_len + 1);
			if (host == nullptr)
			{
				cout << " Error in memory allocation when creating host !" << endl;
			}
			strncpy(host, starthost, host_len);
			host[host_len] = '\0';
		}
	}

	return host;
}
char* get_page(char* request)
{
	int re_len = strlen(request);
	char* page = nullptr;

	char* startpage;
	startpage = strstr(request, "GET ");
	int page_len = 0;
	if (startpage != nullptr)
	{
		startpage = startpage + strlen("GET ");

		while (1)
		{
			if (startpage[page_len] == ' ') //End of host (because its the HTTP request so it dont have ":443")
				break;
			page_len++;
		}
		if (page_len > 0)
		{
			page = (char*)malloc(page_len + 1);
			if (page == nullptr)
			{
				cout << " Error in memory allocation when creating host !" << endl;
			}
			strncpy(page, startpage, page_len);
			page[page_len] = '\0';
		}
	}

	return page;
}
//Ref: https://github.com/sameer2800/HTTP-PROXY/blob/master/proxy.cpp
SOCKET createserverSocket(char* pcAddress, char* pcPort) {
	cout << "connecting to host: " << pcAddress << endl;
	struct addrinfo ahints;
	struct addrinfo* paRes = nullptr;

	int sock;

	/* Get address information for stream socket on input port */
	memset(&ahints, 0, sizeof(ahints));
	ahints.ai_family = AF_INET; //ipv4
	ahints.ai_socktype = SOCK_STREAM;
	ahints.ai_protocol = IPPROTO_TCP; //TCP
	if (getaddrinfo(pcAddress, pcPort, &ahints, &paRes) != 0) {
		cout << " Error in server address format, code: " << WSAGetLastError() << endl;
		return -1;
	}

	/* Create and connect */
	if ((sock = socket(paRes->ai_family, paRes->ai_socktype, paRes->ai_protocol)) < 0) {
		cout << " Error in creating socket to server, code: " << WSAGetLastError() << endl;
		return -1;
	}
	if (connect(sock, paRes->ai_addr, paRes->ai_addrlen) < 0) {
		cout << " Error in connecting to server, code: " << WSAGetLastError() << endl;
		return -1;
	}

	/* Free paRes, which was dynamically allocated by getaddrinfo */
	freeaddrinfo(paRes);

	return sock;
}


bool sendToSocket(const char* buff, SOCKET sockfd, int buff_length, string name_sock)
{

	int total_sent = 0;
	int sent_each;


	while (total_sent < buff_length) {	//Send all
		//cout << "sending to " << name_sock << endl;

		sent_each = send(sockfd, (buff + total_sent), buff_length - total_sent, 0);
		if (sent_each < 0) {
		//	cout << " Error in sending to " << name_sock << ", code: " << WSAGetLastError() << endl;
			return false;
		}
		else if (sent_each == 0) {
		//	cout << " Disconnected, code: " << WSAGetLastError() << endl;
			return false;
		}
		else
			total_sent += sent_each;
	}
	return true;
}

bool revThenSendBack(SOCKET Clientfd, SOCKET Serverfd, char * request, int index) //Because the bits when reciving is too big so read 2000 then send 2000 bits
{
	

	int iRecv = 0;
	char* buf = (char*)malloc(BUF_MAX_SIZE + 1);

	memset(buf, 0, BUF_MAX_SIZE);
//	char * page = get_page(request);
//	int index = have_cached(request);
	if (&data[index] != NULL) {
		for (int i = 0; i < data[index].size(); i++) {
			free(data[index][i]);
		}
	}
	data[index].clear();
	memset(&cache[index], 0, sizeof(index));

	int sum = 0;
	bool isResponseHeader = true;
	bool cc = true;
	while ((iRecv = recv(Serverfd, buf, BUF_MAX_SIZE, 0)) > 0) //recieve 2000 bits
	{
		sendToSocket(buf, Clientfd, BUF_MAX_SIZE, "client");  // send 2000 bits to client	(broswer) 
		if (isResponseHeader) {
			if (can_Cache(buf))
			{
				cc = true;
				char * host = get_host(request);
				char * page = get_page(request);
				char * date = get_date(buf);
				char * etag = get_etag(buf);
				memset(&cache[index], 0, sizeof(CACHE));
				memcpy(&cache[index].host, host, strlen(host) + 1);
				memcpy(&cache[index].page, page, strlen(page) + 1);
				if (date !=NULL)
					memcpy(&cache[index].datetime, date, strlen(date) + 1);
				if (etag != NULL)
					memcpy(&cache[index].etag, etag, strlen(etag + 1));
				isResponseHeader = false;
			}
			else cc = false;
		}
		if (cc == true) {
			char *t = (char*)malloc(BUF_MAX_SIZE);
			memset(t, 0, BUF_MAX_SIZE);
			memcpy(t, buf, BUF_MAX_SIZE);
			data[index].push_back(t);
		}


		memset(buf, 0, iRecv);
	}
//	cout << sum << endl;
	free(buf);

//	free(b);
	//Caching here
//	updateCacheDate(indexOfCache);
	//for (int i = 0; i < cache[indexOfCache].cached.size(); i++) {
	////	sendToSocket(cache[indexOfCache].cached[i], Clientfd, strlen(cache[indexOfCache].cached[i]), "client");
	//	cout << cache[indexOfCache].cached[i] << endl;
	//}

	/* Error handling */
	if (iRecv < 0) {
	//	cout << " Error while recieving from server !" << endl;
		return false;
	}
//	memcpy(&cache[indexOfCache], receiveData, receivedSize + 1);

	return true;
}
bool revThenSendBack2(SOCKET Clientfd, SOCKET Serverfd, char * request) //Because the bits when reciving is too big so read 2000 then send 2000 bits
{

	int iRecv = 0;
	char* buf = (char*)malloc(BUF_MAX_SIZE + 1);
	int index = have_cached(request);
	memset(buf, 0, BUF_MAX_SIZE + 1);
	int sum = 0;
	int i = 0;
	while (i < data[index].size() && data[index][i]) //recieve 2000 bit
	{

		//cout << "rev from server and send back to client !"<< endl;
		memcpy(buf, data[index][i], BUF_MAX_SIZE);
		sendToSocket(buf, Clientfd, BUF_MAX_SIZE, "client");  // send 2000 bits to client	(broswer) 
		memset(buf, 0, iRecv);
		i++;
		break;
	}
	free(buf);

	/* Error handling */
	if (iRecv < 0) {
		return false;


		return true;
	}
}

bool right_request(char* request)
{
	if (strlen(request) <= 0)
	{
		cout << "Empty request!" << endl;
		return false;
	}
	if (strstr(request, "https")) {
		cout << "Ko ho tro https" << endl;
		return false;
	}
	if (strstr(request, "GET") == nullptr && strstr(request, "POST") == nullptr ) //HTTP request
	{
		return false;
	}
	if (strstr(request, "\r\n\r\n") == nullptr) // end request
	{
		cout << "Request doesnt have end characters!" << endl;
		return false;
	}
	return true;
}

char* StringToChar(string str)
{
	int l = str.length();
	char* result = (char*)malloc(l + 1);
	memset(result, 0, l + 1);
	for (int i = 0; i < l; i++)
		result[i] = str[i];
	str[l] = '\0';
	return result;
}

vector<char*> read_black_list(string file_name)
{
	vector<char*> bl;
	ifstream blacklist;
	blacklist.open(file_name);
	string line;
	while (getline(blacklist, line))
	{
		bl.push_back(StringToChar(line));
	}
	return bl;
}


bool send_block_response(SOCKET client)
{
	char* a = block_response;
	int a_l = strlen(a);
	int total_sent = 0;
	int sent_each;
	while (total_sent < a_l) {
		if ((sent_each = send(client, (a + total_sent), a_l - total_sent, 0)) < 0) {
			return false;
		}
		total_sent += sent_each;
	}
	cout << "blocked" << endl;
	closesocket(client);
//	free(a);
	return true;
}

int have_cached(char *request)
{
//	if (indexOfCache < 0) return -1;
	if (request == NULL) return -1;
	char * host = get_host(request), *page = get_page(request);
	for (int i = 0; i < cache_max_size; i++) {
		if (cache[i].host != NULL && cache[i].page != NULL)
		if (strcmp(cache[i].host, host) == 0 && strcmp(cache[i].page, page) == 0) {
			cout << "da cache " << i << endl;
			return i;
		}
	}

	return -1;
}

char * get_date(char * response) {

	char *	date_start = strstr(response, "Last-Modified: ");
	char *	date = nullptr;
	int		date_len = 0;

	if (date_start != nullptr)
	{
		date_start = date_start + strlen("Last-Modified: ");
		while (date_start[date_len] != '\r') {
			date_len++;	
		}
	//	date_len++;
		if (date_len > 0) {
			//cap phat cho "date"
			date = (char*)malloc(date_len + 1);
			if (date == nullptr) {
				cout << "Cap phat bo nho that bai\n";
			}
			else {
				memcpy(date, date_start, date_len);
				date[date_len] = '\0';
			}
		}
	}
	return date;
}
char * get_etag(char * response) {

	char *	etag_start = strstr(response, "ETag: ");
	char *	etag = nullptr;
	int		etag_len = 0;

	if (etag_start != nullptr)
	{
		etag_start = etag_start + strlen("ETag: ");
		while (etag_start[etag_len] != '\r') {
			etag_len++;
		}
	//	etag_len++;
		if (etag_len > 0) {
			//cap phat cho "date"
			etag = (char*)malloc(etag_len + 1);
			if (etag == nullptr) {
				cout << "Cap phat bo nho that bai\n";
			}
			else {
				memcpy(etag, etag_start, etag_len);
				etag[etag_len] = '\0';
			}
		}
	}
	return etag;
}
char *get_response_header(char *response)
{
	if (response == NULL) return NULL;
	char *rp_main = strstr(response, "\r\n\r\n");
	char *rp_head = (char*)malloc(1000);
	if (rp_head == NULL) {
		return NULL;
	}
	memcpy(rp_head, response, 1000);
	rp_head[rp_main - response] = '\0';

	return rp_head;
}
char * rebuilded_rq(int index, char *request) {
	char * rq = (char *)malloc(2000);
	memset(rq, 0, 2000);
	memcpy(rq, request, strlen(request) - 4);
	if (rq == nullptr) return nullptr;
	if (strstr(request, "If-Modified-Since") == NULL && strcmp(cache[index].datetime, "") != 0) {
		strcat(rq, "\r\n");
		strcat(rq, "If-Modified-Since: ");
		strcat(rq, cache[index].datetime);
		strcat(rq, "\r\n\r\n\0");
		//	strcat(rq, "\r\n123456789012345678901234567890\r\n");
	}
	//if (cache[index].etag != nullptr) {
	//	strcat(rq, "\r\n");
	//	strcat(rq, "If-None-Match: ");
	//	strcat(rq, cache[index].etag);
	//	strcat(rq,"\r\n\r\n\0");
	//}
//	cout << "Rq: \n" << rq << endl;
	return rq;
}

bool can_Cache(char *response) {
	if (response == NULL) return false;
	if (strstr(response, "200 OK") == NULL) return false;
	if (strstr(response, "Last-Modified") == NULL && strstr(response, "ETag") == NULL) return false;
	return true;
}
bool isEmptyMem(char *s, int l) {
	for (int i = 0; i < l; i++) {
		if (s[i] != 0) return false;
	}
	return true;
}
void freeData(int index)
{
	if (&data[index] != NULL) {
		for (int i = 0; i < data[index].size(); i++) {
			free(data[index][i]);
		}
	}
}
int freeIndex()
{
	for (int i = 0; i < cache_max_size; i++)
	{
		if (strcmp(cache[i].host, "") == 0)
		{
			recentCache = i;
			return i;
		}
	}
	recentCache = (recentCache + 1) % cache_max_size;
	memset(&cache[recentCache], 0, sizeof(CACHE));
//	freeData(recentCache);
	return 0;
}


