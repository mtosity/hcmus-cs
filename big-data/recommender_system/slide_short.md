Dựa trên nội dung (rating, quá khứ), cộng tác (những người có cùng sở thích), phương pháp lai

- PU learning: xem các tài liệu người dùng cung cấp thuộc
  lớp dương và tập tài liệu ứng viên là mẫu chưa gán nhãn.

- EM+Naïve Bayesian, Co-training, Self-training,...

- Supervised learning: có thể áp dụng nếu người dùng cung cấp cả tài liệu liên quan và không liên quan.

- LU learning: nếu tập hợp liên quan và không liên quan nhỏ, áp dụng học bán giám sát.

Theo nội dung thì không biết cái mới thì rate ntn, rộng rãi nhất vẫn là tiếp cận dựa trên cộng tác (collaboration filtering.)

# Lọc cộng tác sử dụng KNN (k-nearest neighbors)

Xác định độ tương quan giữa profile của người dùng mục
tiêu và profile của những người dùng khác trong cơ sở dữ
liệu để tìm người dùng có chung đặc điểm hoặc sở thích.

Đưa ra dự đoán dựa trên việc kết hợp giá trị từ k người
dùng gần nhất.

Quá trình gồm hai pha chính: hình thành
vùng láng giềng và tư vấn.

## Hình thành vùng láng giềng

So sánh profile của người dùng mục tiêu với tập profile theo
lịch sử T của các người dùng khác để tìm ra top-k người
dùng có chung sở thích.

Dựa trên độ tương tự về điểm đánh
giá sản phẩm, nội dung trang truy
cập, hoặc sản phẩm được mua.

Trong đa số ứng dụng lọc cộng tác, user profile thường là
một tập điểm đánh giá cho một tập con sản phẩm.

Xong rùi đem đi tư vấn cho tập user

## Lọc cộng tác dựa trên hạng mục

Lọc cộng tác dựa trên người dùng thiếu tính mở rộng: làm
thế nào để so sánh người dùng mục tiêu với những người
dùng khác trong thời gian thực để phát sinh lời tư vấn.

Trong khi đó, lọc cộng tác dựa trên hạng mục có thể tính
trước độ tương tự của mọi cặp hạng mục.

## Áp dụng k-NN cho lọc cộng tác

- k-NN dựa trên người dùng hay dựa trên sản phầm đều gặp
  vấn đề số chiều lớn → trong thực tế không thể tính độ tương
  tự giữa các cặp người dùng hay hạng mục.

- Áp dụng các kỹ thuật giảm chiều để thu gọn kích thước user
  profile và item profile.

- Chiếu ma trận người dùng - hạng mục vào không gian nhỏ hơn, ví
  dụ, Principal Component Analysis (PCA).

- Factorize ma trận người dùng – hạng mục thành các biểu diễn thứ
  hạng thấp hơn về người dùng (hoặc hạng mục), ví dụ Singular Value
  Decomposition (SVD).

- Nhận diện đối tượng tương tự trong không gian con.

## Lọc cộng tác sử dụng LKH

- Các hạng mục được mỗi người dùng thanh toán có thể
  được xem như một giao dịch.

- Trong lọc cộng tác, luật X → Y có tiền đề chứa một hay
  nhiều hạng mục trong khi hệ quả chỉ có một hạng mục.

Ví dụ một người xem mấy bộ phim này thuộc hành động thì có thể xem Fast and Furious

Khó khi méo có dữ liệu, hầu hết người dùng chỉ xem (hoặc đánh giá) một tỉ lệ rất
nhỏ trong số các hạng mục sẵn có, do đó khó tìm đủ số
hạng mục chung giữa các user profile.

### Giải pháp của Sarwar et al. 2000.

- Làm nhẹ vấn đề bằng một số kỹ thuật giảm chiều cơ bản.

- Khuyết điểm: một vài hạng mục hữu dụng hoặc thú vị có thể
  bị loại bỏ và do đó không thể xuất hiện trong mẫu kết quả.

```
Ref: Sarwar, B., G. Karypis, J. Konstan, and J. Riedl. Application of
Dimensionality Reduction in Recommender Systems: a case study. In
Proceedings of WebKDD Workshop at the ACM SIGKKD, 2000.
```

### Giải pháp của Fu et al. 2000.

- Giải pháp 1: xếp hạng mọi luật tìm được theo độ giao giữa
  tiền đề của luật và profile của người dùng mục tiêu rồi phát
  sinh top-k tư vấn.

- Giải pháp 2: tìm các người dùng “láng giềng gần” có sở
  thích tương tự với người dùng mục tiêu và đưa ra tư vấn
  dựa trên lịch sử của những người này.

```
Ref: Fu, X., J. Budzik, and K. Hammond. Mining navigation history for
recommendation. In Proceedings of Intl. Conf. on Intelligent User
Interfaces, 2000.
```

### Giải pháp của Lin et al.

- Phát sinh luật kết hợp giữa các người dùng (user
  associations) và giữa các hạng mục (item associations).

- Tự động chọn minimum support để xác định đủ lượng luật
  cho mỗi người dùng mục tiêu.

- Nếu user minimum support lớn hơn ngưỡng, hệ thống sẽ tư
  vấn dựa trên user assocations, ngược lại, sử dụng item
  associations.

```
Ref: Lin, W., S. Alvarez, and C. Ruiz. Efficient adaptive support
association rule mining for recommender systems. Data Mining and
Knowledge Discovery, 2002, 6(1): p. 83-105.
```

## So khớp user profile và tiền đề luật

- Thuật toán duyệt theo chiều sâu trên Frequent Itemset
  Graph đến mức w và phát sinh ứng viên từ các nút con
  của nút n thỏa việc so khớp. Giá trị tư vấn của ứng viên dựa trên độ tin cậy của luật tương ứng
  chứa duy nhất ứng viên ở phần hệ quả.

## Áp dụng LKH cho lọc cộng tác

- “hiếm nhưng
  quan trọng” thường bị bỏ sót do những hạng mục này xuất hiện không thường xuyên nên bị loại bỏ
  bởi ngưỡng minimum support toàn cục.

- Giải pháp multiple minimum supports cho phép người
  dùng xác định riêng ngưỡng support cho từng hạng mục.

## Lọc cộng tác sử dụng Matrix Factorization

- Phân rã ma trận M thành tích của một vài ma trận hệ số

```
timeSVD++ (Netflix Prize contest 2006), Nonnegative Matrix
Factorization, MaximumMargin Matrix Factorization, và
Probabilistic Matrix Factorization
```

- Matrix factorization thuộc về nhóm mô hình hệ số tiềm ẩn
  (latent factor models).

- Biến tiềm ẩn (latent variables) biểu diễn lý do nền tảng của
  việc mua/sử dụng sản phẩm của một người dùng.

  • Còn gọi là đặc trưng (feature), khía cạnh (aspect), hay hệ số (factor).

- Tương tác có thể xảy ra giữa người dùng với sản phẩm
  thông qua biến tiềm ẩn được tính toán để đưa ra tư vấn.

```
Đọc mục 12.4.5, trang 586, tài liệu tham khảo Web Data
Mining, 2nd edition, Bing Liu.
```
