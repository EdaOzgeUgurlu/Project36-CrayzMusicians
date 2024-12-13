# Project36 Çılgın Müzisyenler API 🎶

## Genel Bakış 📋
Bu API, müzisyen listesi yönetimi için tasarlanmıştır. Müzisyen verileri üzerinde CRUD işlemleri (Oluşturma, Okuma, Güncelleme, Silme) yapmaya olanak tanır. Her müzisyenin ID, Ad, Meslek ve Eğlenceli Özellik gibi özellikleri bulunur.

---

## Endpointler 🌐

### **GET** `/api/musicians` 🔍
Tüm müzisyenlerin listesini getirir.

**Yanıt:**
- ✅ 200 OK: Tüm müzisyenlerin listesi.

### **GET** `/api/musicians/{id}` 🔢
Bir müzisyeni ID'sine göre getirir.

**Parametreler:**
- `id` (int): Müzisyenin ID'si (minimum değer: 1).

**Yanıt:**
- ✅ 200 OK: Müzisyen verisi.
- ❌ 404 Bulunamadı: Belirtilen ID'ye sahip bir müzisyen yoksa.

### **GET** `/api/musicians/musicians/{musiciansName}` 🧑‍🎤
Müzisyenleri isimlerine göre arar (büyük-küçük harf duyarsız).

**Parametreler:**
- `musiciansName` (string): Müzisyenin adının tümü veya bir bölümü.

**Yanıt:**
- ✅ 200 OK: Eşleşen müzisyenlerin listesi.
- ❌ 404 Bulunamadı: Hiçbir müzisyen isme uymuyorsa.

### **GET** `/api/musicians/ID-range` 🛠️
Belirtilen ID aralığındaki müzisyenleri getirir.

**Sorgu Parametreleri:**
- `minId` (int): Minimum ID değeri.
- `maxId` (int): Maksimum ID değeri.

**Yanıt:**
- ✅ 200 OK: Belirtilen aralıktaki müzisyenlerin listesi.

### **POST** `/api/musicians` ➕
Listeye yeni bir müzisyen ekler.

**İstek Gövdesi:**
```json
{
  "Name": "string",
  "Profession": "string",
  "FunFeature": "string"
}
```
**Yanıt:**
- 🎉 201 Oluşturuldu: Yeni eklenen müzisyen.

### **PUT** `/api/musicians/update/{id}/{updatedName}` ✏️
Bir müzisyenin adını ID'sine göre günceller.

**Parametreler:**
- `id` (int): Müzisyenin ID'si (minimum değer: 1).
- `updatedName` (string): Müzisyenin yeni adı.

**Yanıt:**
- ✅ 200 OK: Güncellenen müzisyen.
- ❌ 404 Bulunamadı: Belirtilen ID'ye sahip bir müzisyen yoksa.

### **PUT** `/api/musicians/update/{id}` 🔄
Bir müzisyenin tüm bilgilerini ID'sine göre günceller.

**İstek Gövdesi:**
```json
{
  "Name": "string",
  "Profession": "string",
  "FunFeature": "string"
}
```
**Yanıt:**
- ✅ 200 OK: Güncellenen müzisyen.
- ❌ 404 Bulunamadı: Belirtilen ID'ye sahip bir müzisyen yoksa.

### **DELETE** `/api/musicians/delete/{id}` 🗑️
Bir müzisyeni ID'sine göre siler.

**Parametreler:**
- `id` (int): Müzisyenin ID'si (minimum değer: 1).

**Yanıt:**
- ✅ 200 OK: Başarı mesajı.
- ❌ 404 Bulunamadı: Belirtilen ID'ye sahip bir müzisyen yoksa.

### **PATCH** `/api/musicians/update/{id}` ✂️
Bir müzisyenin adını ID'sine göre kısmi olarak günceller.

**İstek Gövdesi:**
```json
{
  "Name": "string"
}
```
**Yanıt:**
- ✅ 200 OK: Güncellenen müzisyen.
- ❌ 404 Bulunamadı: Belirtilen ID'ye sahip bir müzisyen yoksa.
- ❗ 400 Hatalı İstek: İstek gövdesi geçersizse.

---

## Veri Modeli 📦
**Müzisyen:**
```json
{
  "ID": "int",
  "Name": "string",
  "Profession": "string",
  "FunFeature": "string"
}
```

---

## Başlangıç 🚀

### Gereksinimler 🛠️
- [.NET 6 SDK](https://dotnet.microsoft.com/download/dotnet/6.0)
- [Visual Studio](https://visualstudio.microsoft.com/) veya [Visual Studio Code](https://code.visualstudio.com/) gibi bir kod düzenleyici.

### Uygulamanın Çalıştırılması 🖥️
1. Depoyu klonlayın.
2. Projeyi tercih ettiğiniz IDE'de açın.
3. Uygulamayı derleyin ve çalıştırın.
4. API endpointlerini test etmek için [Postman](https://www.postman.com/) gibi araçları veya bir tarayıcıyı kullanın.

---

## Lisans 📜
Bu proje MIT Lisansı ile lisanslanmıştır. Ayrıntılar için `LICENSE` dosyasına bakın.

---

## Teşekkürler 🙏

