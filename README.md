# LinkBilgisayarProject

Temel crud ve custom endpointler yazıldı, Role bazlı access token ve refresh token doğrulama eklendi. Geri kalan isterler yapılmaya devam edilecek

# Kayıt Rehberi Asp.Net Core Api Projesi

X firması bizden müşterileri için kayıt rehberi uygulaması geliştirmemizi
istemektedir. Proje’nin front-end tarafı angular,react veya vue.js kullanılarak geliştirilecektir.
Backend tarafı ise asp.net core api ile geliştirilecektir.
Sizden beklenen ön yüzde geliştirilecek olan angular,react veya vue.js web uygulaması için
gerekli API(Restful service) projesini yazmanız.

Firma’nın beklentileri :

 Müşterinin isim,soy isim,email,fotograf,telefon ve şehir bilgilerinin tutulması
 Müşteri ile yapılan ticari faliyet bilgilerinin tutulması
 Rehbere, müşteri kaydetme,güncelleme,silme,listeleme,fotoğraf güncelleme,toplu silme
işlemi ve müşteri tiraci faaliyetler ile ilgili CRUD operasyonlarının gerçekleştirilmesi.
 Rehbere kayıt gerçekleştirecek çalışanların farklı rollere sahip olması( Admin ve Editor
Rolleri)
 Admin,Editor isminde 2 tane rol tanımlamasının olması.
 Admin rol, tüm işlemleri gerçekleştirebilecek.
 Editor rol ise sadece kaydetme,güncelleme ve listeleme işlemlerini gerçekleştirebilecek.
 Aynı telefon numarasına sahip ama farklı isim ile kaydedilmiş müşterilerin tesbit
edilmesi.
 Kaydedilen müşteri fotoğraflarına watermark(filigran) eklenecektir.
 Aylık olarak email yoluyla hangi şehirde kaç tane müşteri olduğu raporlancak.
 Haftalık olarak en fazla tiraci faliyete sahip ilk 5 müşteri email yoluyla raporlanacak. Bu
rapor admin rolune sahip olanlara gönderilecektir.
 Rapor’lar excel formatında olacak
 Eski raporlara erişilebilecek ve indirilebilecek.

Assessment Notları:
Projede Login sistemi olacaktır. Token ve Refresh token kullanılacaktır. Role bazlı üyelik sistemi
olacaktır. Uygulama ilk ayağa kalktığında Admin ve Editor rolune sahip üye datalarının db’ye
eklemiş olması gerekmektedir. ( örnek üye dataları ekleyebilirsiniz )

Müşteri fotoğraflarına watermark ekleme işlemi, API projesinde dar boğaz yaşatmaması için ayrı
bir process’de gerçekleştirilecektir. Bu görev için ; RabbitMQ ve WorkerService kullanılacaktır.
Watermark olarak, eklencek resimde “www.mysite.com” yazısınının olması yeterlidir.
Müşteri raporlama işlemleri için Quartz Library kullanılacaktır.
Ticari Faliyet tablosunda ; Müşteri ID,Hizmet (yapılan iş ),Fiyat ve tarih alanlarının tutulması
yeterlidir. Bir müşterinin birden fazla faliyet data’sı olabilir.
Haftalık Raporda : Müşteri Adı, Soyadı,Tel, Toplam Ticari faliyet Sayısı, ve Toplam Fiyat alanları
olması yeterlidir.

Not : Projeyi kodlarken ilk olarak parçalara ayırın. Daha sonra en basit parçadan başlayıp en
zora doğru ilerleyin. Bol Şanslar 

Kullanılacak Teknolojiler
 Veritabanı : PostgreSQL
 Proje : Asp.Net Core API
 Rapor : Quartz Library
 Message Broker : RabbitMQ
