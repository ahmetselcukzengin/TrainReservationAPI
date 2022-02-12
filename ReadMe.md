<h2>Tren Rezervasyon API </h2>
Genel Bilgiler
Bir tren rezervasyonu uygulaması için, istenilen rezervasyonunun yapılıp yapılamayacağını ve yapılabiliyorsa hangi vagon için rezervasyon onaylanabileceğini belirleyen bir HTTP API geliştirilecektir.

API, HTTP Post isteklerine yanıt verecektir. 

HTTP API'a tren bilgileri ve kaç kişilik rezervasyon istenildiği gönderilecek, geliştirilecek algoritma rezervasyon yapılıp yapılamayacağı bilgisini dönecektir. 

<h4>Gereksinimler</h4>

- Bir tren içinde birden fazla vagon bulunabilir

- Her vagonun farklı kişi kapasitesi olabilir

- Online rezervasyonlarda, bir vagonun doluluk kapasitesi %70'i geçmemelidir. Yani vagon kapasitesi 100 ise ve 70 koltuk dolu ise, o vagona rezervasyon yapılamaz.

- Bir rezervasyon isteği içinde birden fazla kişi olabilir.

- Rezervasyon isteği yapılırken, kişilerin farklı vagonlara yerleşip yerleştirilemeyeceği belirtilir. Bazı rezervasyonlarda tüm yolcuların aynı vagonda olması istenilirken, bazılarında farklı vagonlar da kabul edilebilir.

- Rezervasyon yapılabilir durumdaysa, API hangi vagonlara kaçar kişi yerleşeceği bilgisini dönecektir.

<h4>API Request ve Response Formatı</h4>
Input formatı aşağıdaki gibidir. Rezervasyon istenilen trenin bilgileri, vagon ayrıntıları, kaç kişilik rezervasyon istenildiği ve kişilerin farklı vagonlara yerleştirilip yerleştirilemeyeceği bilgileri input içinde yer alır;


```
{
    "Tren":
    {
        "Ad":"Başkent Ekspres",
        "Vagonlar":
        [
            {"Ad":"Vagon 1", "Kapasite":100, "DoluKoltukAdet":50},
            {"Ad":"Vagon 2", "Kapasite":90, "DoluKoltukAdet":80},
            {"Ad":"Vagon 3", "Kapasite":80, "DoluKoltukAdet":80}
        ]
    },
    "RezervasyonYapilacakKisiSayisi":3,
    "KisilerFarkliVagonlaraYerlestirilebilir":true
}
```

Dönüş formatı aşağıdaki gibidir.

```
{
    "RezervasyonYapilabilir":true,
    "YerlesimAyrinti":[
        {"VagonAdi":"Vagon 1","KisiSayisi":2},
        {"VagonAdi":"Vagon 2","KisiSayisi":1}
    ]
}
```
Rezervasyon yapılamıyorsa YerlesimAyrinti bos array olacaktır; 

```
{
    "RezervasyonYapilabilir":true,
    "YerlesimAyrinti":[]
}
```

<hr />
<h2>Projeyi Ayağa Kaldırmak ve Test Etmek</h2>
Projeyi Releases altındaki Publish dosyasını indirdikten sonra "TrainReservationAPI.exe"'i çalıştırarak ayağa kaldırabilirsiniz.

Proje ayağa kalktığında bu şekilde gözükecektir:
![image](https://user-images.githubusercontent.com/73847397/153709243-594adc23-9605-4b47-b899-676670341773.png)

Aşağıdaki durumları test edebilirsiniz.</br>
Durum1:
![image](https://user-images.githubusercontent.com/73847397/153709328-c7ffcd12-7fe1-4d43-bc6b-04ddd86e04dc.png)
Durum2:
![image](https://user-images.githubusercontent.com/73847397/153709339-78bb5b2a-4edf-4577-8a26-ddc08afe5a75.png)
Durum3:
![image](https://user-images.githubusercontent.com/73847397/153709333-6273fe96-f2a5-4a18-85f6-d67071e793e2.png)
Durum4:
![image](https://user-images.githubusercontent.com/73847397/153709362-9febe178-0eaf-4100-b957-489b9278ee9c.png)
Durum5:
![image](https://user-images.githubusercontent.com/73847397/153709383-66799233-6436-434e-a2e4-8ba91023ab76.png)
