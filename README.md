# Sorun
Mengakses lokasi file dan direktori menjadi lebih mudah.



## **sorun** *<argumen>*

| Argumen         | Deskripsi                                       |
|-----------------|-------------------------------------------------|
| :l or :location | Membuka lokasi program                          |
| :d or :data     | Membuka lokasi data file sorun                  |
| :v or :version  | Menampilkan versi program                       |
| :h or :help     | Mengarah ke github untuk informasi lebih lanjut |

contoh untuk membuka lokasi program sorun, dapat dituliskan menjadi: 
**sorun :l**

| Argumen     | Deskripsi                                                    |
| ----------- | ------------------------------------------------------------ |
| :a or :add  | Memindahkan file sorun dari suatu direktori ke lokasi data sorun |
| :o or :open | Membuka isi file sorun                                       |

untuk argumen :a membutuhkan argumen tambahan yaitu path dari file sorun yang ingin ditambahkan. Contoh penulisannya:

> **sorun :a** *<file_sorun1>* *<file_sorun2>* *<file_sorunN>*

untuk argumen :o membutuhkan argumen tambahan yaitu nama file sorun tanpa extension, yang telah ditambahkan. Contoh penulisannya:

> **sorun :o** *<nama_file>*




## file .sorun

Semua lokasi file dan direktori perlu dibuatkan dalam sebuah file dengan extension **.sorun**. Untuk penggunaan file sorun dapat ditulis dengan:

> **sorun** *<nama_file>* *<inisial>*

Setiap baris pada file memuat informasi berikut:

| Informasi    | Deskripsi                                                    |
| ------------ | ------------------------------------------------------------ |
| identifikasi | Mengidentifikasi apakah lokasi merupakan direktori, file atau url |
| inisial      | Memberikan nama singkat pada lokasi agar mudah diakses       |
| lokasi       | Menginformasikan direktori atau file atau url yang akan dibuka |

Pada informasi identifikasi dapat menggunakan perintah berikut:

| Perintah | Deskripsi                                                                       |
|----------|---------------------------------------------------------------------------------|
| -d       | Mengidentifikasikan lokasi adalah direktori                                     |
| -f       | Mengidentifikasikan lokasi adalah file                                          |
| -u       | Mengidentifikasikan lokasi adalah url                                           |
| -p       | Mengidentifikasikan lokasi adalah program                                       |
| -s       | Mengidentifikasikan lokasi adalah file yang akan diselect saat membuka explorer |

Contoh file .sorun, misalkan nama filenya adalah **data.sorun**:

```sorun
-d||pic||C:\Users\AbdullahUbaid\Pictures
-f||me||"C:\Users\AbdullahUbaid\Pictures\Abdullah_Ubaids.png"
-s||sme||"C:\Users\AbdullahUbaid\Pictures\Abdullah_Ubaids.png"
-u||github||https://github.com/
-p||jpc||"D:\Program Files\jcpicker.exe"
```

Setelah menambahkan file ke lokasi data sorun. Selanjutnya misalkan kita ingin membuka direktori pictures maka kita dapat menuliskannya menjadi:

> **sorun data pic**

Keterangan:

- sorun: untuk nama programnya
- data: untuk nama filenya
- pic: untuk inisial lokasi yang ingin dibuka

> **Catatan:** Perlu menambahkan program sorun terlebih dahulu ke path environment windows.

