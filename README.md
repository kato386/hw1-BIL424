# hw1-BIL424

Bu proje BIL424 dersi ilk ödevi için yapılmıştır.

# Özellikler
## Zıplama
Karakterimiz(Zombi) yere(ground ve taş objeleri) temas etmesi koşuluyla klavyeden boşluk tuşuna basıldığı zaman havaya zıplar. Havadayken bir kere daha boşluk tuşuna basılırsa bir defaya mahsus olarak zıplayabilir.

## WASD yönlendirme
Karakterimiz tuşlarıyla yönlendirilir.Hareket halindeyken animasyonu idle durumundan walking durumuna geçer.

## Koşma özelliği
Karakterimiz yürürken shift tuşuna basılı tuttuğu zaman koşma durumuna geçer ve hızı artar aynı zamanda animasyonu koşma animasyonuna geçer.Skilli kullandığımız andan itibaren 4 saniye cooldown süresi bulunmaktadır.

## Skill(Taş fırlatma)
Karakterimiz herhangi bir durumda iken Q tuşuna bastığı zaman ileriye doğru bir taş objesi yaratır ve fırlatır. Bu aşamada attack animasyonunu oynatır.Skilli kullandığımız andan itibaren 3 saniye cooldown süresi bulunmaktadır.

## Anahtarı alma.
Karakterimiz anahtar objesine dokunduğu zaman key objesini almış sayılır ve key objesi kaybolur.

## Kapıyı açma
Karakterimiz önceden anahtar objesini aldığı zaman kapı objesine dokunurken E tuşuna basarsa kapı açılır ve açılma animasyonunu uygular.Daha önce key objesini almamışsa kapı açılmaz.


## Çözüm yolları :
Zıplamak için boşlukla karakterime kuvvet uyguladığım zaman ilk olarak sınırsız olarak zıplıyordu. Bunu engellemek için yer objesiyle etkileşimi kontrol edip. Double jump için ise yapılan zıplama sayısını her zıplama esnasında kontrol edip 2 kere zıplamayı sağladım.

Görünümü güzelleştirmek için indirdiğim player objesinin assetlerinde bulunan animasyonları kullandım.Bu durumlara da kodun içinde oluşturduğum Animator objesiyle eriştim.isRunning isWalking gibi bool değerleri kodda buna göre düzenleyerek Animatorun içindeki stateleri değiştirdim.

Skill kullanım aşamasında ise oluşturduğum taş objeleri en başta karakterimin içinde oluştuğu için etkileşime girerek istediğimden farklı hareketler yapıyordu. Bunun için oluşturulan objenin konumunu karakterin konumunun ilerisinde oluşturarak düzelttim. Ve oluşturalan objeye playerin ileri yönlü vektörü şeklinde kuvvet uygulayarak fırlatılmasını sağladım.

Kapıyla etkileşimde kapının hareketini kısıtlamak için de kapının rigidbodysinden constrainsden positionlarını freezeledim.
