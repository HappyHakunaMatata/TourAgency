using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using TourAgency.Models;

namespace TourAgency.Data.SaveTo
{
    public class AddDataAirport
    {
        private AppDbContext _context;
        public AddDataAirport(AppDbContext context)
        {
            _context = context;
        }
        
        private static List<DataAirport> DataAirports = new List<DataAirport>()
        {
              new DataAirport(){city = "Анапа", name = "Vityazevo имени Владимира Коккинаки", symbol = "AAQ", link = "https://aaq.aero/"},
              new DataAirport(){city = "Архангельск",name = "Arkhangelsk, Talagi",symbol = "ARH",link = "http://arhaero.ru/pax"},
              new DataAirport(){city = "Астрахань",name = "Astrakhan Narimanovo имени Бориса Кустодиева",symbol = "ASF",link = "http://аэропортастрахань.рф/"},
              new DataAirport(){city = "Барнаул",name = "Barnaul",symbol = "BAX",link = "http://www.airaltay.ru/"},
              new DataAirport(){city = "Белгород",name = "Belgorod имени Владимира Шухова",symbol = "EGO",link = "http://belgorodavia.ru/"},
              new DataAirport(){city = "Благовещенск",name = "Ignatyevo имени Николая Муравьева-Амурского",symbol = "BQS",link = "http://www.amurair.ru/"},
              new DataAirport(){city = "Братск",name = "Bratsk",symbol = "BTK",link = "http://aerobratsk.ru/index.html"},
              new DataAirport(){city = "Владивосток",name = "Knevichi Zapadnye имени Владимира Арсеньева",symbol = "VVO",link = "http://vvo.aero/"},
              new DataAirport(){city = "Волгоград",name = "Gumrak имени Алексея Маресьева",symbol = "VOG",link = "http://new.mav.ru/"},
              new DataAirport(){city = "Воронеж",name = "Voronezh, Chertovitskoye",symbol = "VOZ",link = "http://voz.aero/"},
              new DataAirport(){city = "Горно-Алтайск",name = "Gorno-Altaysk имени Николая Рериха",symbol = "RGK",link = "http://www.ga-DataAirport.ru/"},
              new DataAirport(){city = "Екатеринбург",name = "Koltsovo имени Акинфия Демидова",symbol = "SVX",link = "http://www.koltsovo.ru/"},
              new DataAirport(){city = "Иркутск",name = "Irkutsk",symbol = "IKT",link = "http://www.iktport.ru/"},
              new DataAirport(){city = "Казань",name = "Kazan",symbol = "KZN",link = "http://www.kazan.aero/"},
              new DataAirport(){city = "Калининград",name = "Khrabrovo",symbol = "KGD",link = "http://www.kgd.aero/"},
              new DataAirport(){city = "Караганда",name = "Karaganda",symbol = "KGF",link = "http://kgf.aero/rus/"},
              new DataAirport(){city = "Кемерово",name = "Kemerovo",symbol = "KEJ",link = "http://airkem.ru/?show=1"},
              new DataAirport(){city = "Краснодар",name = "Krasnodar, Pashkovsky",symbol = "KRR",link = "http://basel.aero/krasnodar/"},
              new DataAirport(){city = "Красноярск",name = "Krasnoyarsk, Emelyanovo",symbol = "KJA",link = "http://DataAirport-krasnoyarsk.ru/"},
              new DataAirport(){city = "Магнитогорск",name = "Magnitogorsk",symbol = "MQF",link = "http://www.airmgn.ru/"},
              new DataAirport(){city = "Минеральные Воды",name = "Mineralnye Vody",symbol = "MRV",link = "http://mvDataAirport.ru/"},
              new DataAirport(){city = "Москва",name = "Domodedovo имени Михаила Ломоносова",symbol = "DME",link = "http://www.domodedovo.ru/"},
              new DataAirport(){city = "Москва",name = "Sheremetevo имени Александра Пушкина",symbol = "SVO",link = "http://www.svo.aero/"},
              new DataAirport(){city = "Москва",name = "Vnukovo",symbol = "VKO",link = "http://www.vnukovo.ru/"},
              new DataAirport(){city = "Москва",name = "Zhukovskiy",symbol = "ZIA",link = "http://www.zia.aero/"},
              new DataAirport(){city = "Мурманск",name = "Murmansk",symbol = "MMK",link = "http://www.DataAirport-murmansk.ru/"},
              new DataAirport(){city = "Нижневартовск",name = "Nizhnevartovsk",symbol = "NJC",link = "http://www.nvavia.ru/"},
              new DataAirport(){city = "Нижнекамск",name = "Nizhnekamsk, Begishevo",symbol = "NBC",link = "http://nbc.aero/"},
              new DataAirport(){city = "Нижний Новгород",name = "Nizhny Novgorod, Strigino",symbol = "GOJ",link = "http://www.DataAirportnn.ru/"},
              new DataAirport(){city = "Новосибирск",name = "Novosibirsk, Tolmachevo",symbol = "OVB",link = "https://www.tolmachevo.ru/"},
              new DataAirport(){city = "Новый Уренгой",name = "Novy Urengoy",symbol = "NUX",link = "http://nux.aero/"},
              new DataAirport(){city = "Омск",name = "Omsk",symbol = "OMS",link = "http://www.aeroomsk.ru/"},
              new DataAirport(){city = "Оренбург",name = "Orenburg",symbol = "REN",link = "http://www.orenDataAirport.ru/"},
              new DataAirport(){city = "Пермь",name = "Perm, Bolshoe Savino",symbol = "PEE",link = "http://www.aviaperm.ru/"},
              new DataAirport(){city = "Петропавловск-Камчатский",name = "Yelizovo",symbol = "PKC",link = "http://www.DataAirport-pkc.ru/"},
              new DataAirport(){city = "Ростов-на-Дону",name = "Rostov",symbol = "ROV",link = "http://rov.aero/"},
              new DataAirport(){city = "Самара",name = "Samara, Kurumoch",symbol = "KUF",link = "http://uwww.aero/"},
              new DataAirport(){city = "Санкт-Петербург",name = "Pulkovo",symbol = "LED",link = "http://www.pulkovoDataAirport.ru/"},
              new DataAirport(){city = "Саратов",name = "Saratov, Tsentralnyy",symbol = "RTW",link = "http://www.saratovairlines.ru/Pages/Default.aspx"},
              new DataAirport(){city = "Симферополь",name = "Simferopol",symbol = "SIP",link = "http://sipaero.ru/"},
              new DataAirport(){city = "Сочи",name = "Sochi",symbol = "AER",link = "http://basel.aero/sochi/"},
              new DataAirport(){city = "Сургут",name = "Surgut",symbol = "SGC",link = "http://www.DataAirport-surgut.ru/"},
              new DataAirport(){city = "Сыктывкар",name = "Syktyvkar",symbol = "SCW",link = "http://www.komiaviatrans.ru/scw.php?m=2"},
              new DataAirport(){city = "Томск",name = "Tomsk, Bogashevo",symbol = "TOF",link = "http://www.tomskDataAirport.ru/"},
              new DataAirport(){city = "Тюмень",name = "Roschino",symbol = "TJM",link = "http://www.tjm.aero/"},
              new DataAirport(){city = "Улан-Удэ",name = "Baikal (Mukhino)",symbol = "UUD",link = "http://www.DataAirportbaikal.ru/"},
              new DataAirport(){city = "Ульяновск",name = "Barataevka",symbol = "ULV",link = "http://ulk.aero/"},
              new DataAirport(){city = "Ульяновск",name = "Ulyanovsk-Vostochny",symbol = "ULY",link = "http://ulvost.aero/"},
              new DataAirport(){city = "Уфа",name = "Ulyanovsk-Vostochny",symbol = "Ufa",link = "http://www.DataAirportufa.ru/"},
              new DataAirport(){city = "Хабаровск",name = "Khabarovsk",symbol = "KHV",link = "http://www.airkhv.ru/"},
              new DataAirport(){city = "Чебоксары",name = "Cheboksary",symbol = "CSY",link = "http://www.airchuvashia.ru/"},
              new DataAirport(){city = "Челябинск",name = "Cheliabinsk",symbol = "CEK",link = "http://www.aeroport-74.ru/"},
              new DataAirport(){city = "Чита",name = "Chita",symbol = "HTA",link = "http://www.aerochita.ru/"},
              new DataAirport(){city = "Южно-Cахалинск",name = "Yuzhno-Sakhalinsk",symbol = "UUS",link = "http://DataAirportus.ru/"},
              new DataAirport(){city = "Якутск",name = "Yakutsk",symbol = "YKS",link = "http://yks.aero/"},

              new DataAirport(){city = "Брисбен",name = "Brisbane",symbol = "BNE",link = "http://www.bne.com.au/"},
              new DataAirport(){city = "Мельбурн",name = "Tullamarine",symbol = "MEL",link = "http://melbourneDataAirport.com.au/"},
              new DataAirport(){city = "Сидней",name = "Kingsford Smith DataAirport",symbol = "SYD",link = "http://www.sydneyDataAirport.com.au/"},

              new DataAirport(){city = "Вена",name = "Vienna (Flughafen Wien-Schwechat)",symbol = "VIE",link = "http://www.viennaDataAirport.com/"},
              new DataAirport(){city = "Зальцбург",name = "Salzburg DataAirport W. A. Mozart",symbol = "SZG",link = "http://www.salzburg-DataAirport.com/en/"},
              new DataAirport(){city = "Инсбрук",name = "Innsbruck",symbol = "INN",link = "http://www.innsbruck-DataAirport.com/en/"},

              new DataAirport(){city = "Баку",name = "Heydar Aliyev International DataAirport",symbol = "GYD",link = "http://www.DataAirport.az/"},
              new DataAirport(){city = "Гянджа",name = "Ganja",symbol = "KVD",link = ""},

              new DataAirport(){city = "Буэнос-Айрес",name = "Buenos Aires Ministro Pistarini",symbol = "EZE",link = "http://www.aa2000.com.ar/aeropuertos.aspx"},

              new DataAirport(){city = "Минск",name = "Minsk",symbol = "MSQ",link = "http://DataAirport.by/"},

              new DataAirport(){city = "Бургас",name = "Burgas",symbol = "BOJ",link = "http://www.bourgas-DataAirport.com/Home/tabid/36/language/ru-RU"},
              new DataAirport(){city = "Варна",name = "Varna",symbol = "VAR",link = "http://www.varna-DataAirport.bg/Home/tabid/36/language/ru-RU"},
              new DataAirport(){city = "София",name = "Sofia",symbol = "SOF",link = "https://www.sofia-DataAirport.bg/en/passengers"},
              new DataAirport(){city = "Пловдив",name = "Plovdiv",symbol = "PDV",link = "http://www.plovdivDataAirport.com/?lang=2"},

              new DataAirport(){city = "Рио-де-Жанейро",name = "Galeão Antonio Carlos Jobim",symbol = "GIG",link = "http://www.aeroportogaleao.net/en/"},
              new DataAirport(){city = "Сан-Паулу",name = "Guarulhos",symbol = "GRU",link = "http://www.gru.com.br/en-us/"},

              new DataAirport(){city = "Лондон",name = "Gatwick",symbol = "LGW",link = "http://www.gatwickDataAirport.com/"},
              new DataAirport(){city = "Лондон",name = "Heathrow",symbol = "LHR",link = "http://www.heathrow.com/"},

              new DataAirport(){city = "Ньячанг",name = "Nha Trang",symbol = "CXR",link = "https://www.nhatrangDataAirport.com/"},
              new DataAirport(){city = "Фу Куок",name = "San bay Phu Quoc",symbol = "PQC",link = ""},
              new DataAirport(){city = "Хошимин",name = "",symbol = "SGN",link = "https://www.hochiminhcityDataAirport.com/"},

              new DataAirport(){city = "Берлин",name = "Schoenefeld",symbol = "SXF",link = "http://www.berlin-DataAirport.de/en/travellers-sxf/index.php"},
              new DataAirport(){city = "Берлин",name = "Tegel",symbol = "TXL",link = "http://www.berlin-DataAirport.de/en/travellers-txl/index.php"},
              new DataAirport(){city = "Дюссельдорф",name = "Duesseldorf",symbol = "DUS",link = "http://www.dus.com/en"},
              new DataAirport(){city = "Мюнхен",name = "Franz Josef Strauss",symbol = "MUC",link = "http://www.munich-DataAirport.de/en/consumer/index.jsp"},
              new DataAirport(){city = "Франкфурт",name = "Frankfurt",symbol = "FRA",link = "http://www.frankfurt-DataAirport.com/content/frankfurt_DataAirport/en.html"},

              new DataAirport(){city = "Афины",name = "Athens, Eleftherios Venizelos",symbol = "ATH",link = "http://www.aia.gr/traveler/"},
              new DataAirport(){city = "Ираклион",name = "Heraklion",symbol = "HER",link = "http://www.heraklion-DataAirport.info/"},
              new DataAirport(){city = "Каламата",name = "Kalamata",symbol = "KLX",link = ""},
              new DataAirport(){city = "Корфу",name = "Corfu International DataAirport",symbol = "CFU",link = "http://www.corfu-DataAirport.com/"},
              new DataAirport(){city = "Кос",name = "Kos Island International DataAirport",symbol = "KGS",link = "http://www.kosDataAirportguide.com/"},
              new DataAirport(){city = "Закинтос",name = "Zakynthos International DataAirport",symbol = "ZTH",link = "http://www.zakynthos-DataAirport.com/"},
              new DataAirport(){city = "Родос",name = "Rhodes",symbol = "RHO",link = "http://www.rhodes-DataAirport.info/"},
              new DataAirport(){city = "Салоники",name = "Thessaloniki",symbol = "SKG",link = "http://www.thessalonikiDataAirport.com/"},

              new DataAirport(){city = "Пунта Кана",name = "Punta Cana",symbol = "PUJ",link = "http://www.puntacanainternationalDataAirport.com/"},

              new DataAirport(){city = "Каир",name = "Cairo",symbol = "CAI",link = "http://www.cairo-DataAirport.com/"},
              new DataAirport(){city = "Луксор",name = "Luxor",symbol = "LXR",link = ""},
              new DataAirport(){city = "Марса Алам",name = "Marsa Alam",symbol = "RMF",link = "http://www.portghalib.com/DataAirport/"},
              new DataAirport(){city = "Таба",name = "Taba",symbol = "TCP",link = ""},
              new DataAirport(){city = "Хургада",name = "Hurghada",symbol = "HRG",link = "http://www.hurghada-DataAirports.com/"},
              new DataAirport(){city = "Шарм эль Шейх",name = "Sharm El Sheikh",symbol = "SSH",link = ""},

              new DataAirport(){city = "Гоа",name = "Goa, Dabolim",symbol = "GOI",link = ""},
              new DataAirport(){city = "Дели",name = "Delhi, Indira Gandhi",symbol = "DEL",link = ""},
              new DataAirport(){city = "Тривандрум",name = "Thiruvananthapuram International",symbol = "TRV",link = ""},

              new DataAirport(){city = "Денпасар",name = "Denpasar, Ngurah Rai",symbol = "DPS",link = ""},

              new DataAirport(){city = "Аликанте",name = "Alicante El Altet",symbol = "ALС",link = "http://www.alicante-DataAirport.net/"},
              new DataAirport(){city = "Барселона",name = "Barcelona",symbol = "BCN",link = "http://www.aeropuertobarcelona-elprat.com/ingl/index.html"},
              new DataAirport(){city = "Ибица",name = "Ibiza",symbol = "IBZ",link = "http://www.aena.es/en/ibiza-DataAirport/index.html"},
              new DataAirport(){city = "Лас Пальмас",name = "Las Palmas, Gran Canaria",symbol = "LPA",link = ""},
              new DataAirport(){city = "Мадрид",name = "Madrid",symbol = "MAD",link = ""},
              new DataAirport(){city = "Малага",name = "Malaga, PabloRuizPicasso",symbol = "AGP",link = ""},
              new DataAirport(){city = "Пальма де Майорка",name = "Palma de Mallorca, Son Sant Joan",symbol = "PMI",link = ""},
              new DataAirport(){city = "Севилья",name = "Seville, San Pablo",symbol = "SVQ",link = ""},
              new DataAirport(){city = "Тенерифе",name = "Tenerife SurReinaSofia",symbol = "TFS",link = ""},
              new DataAirport(){city = "Тенерифе",name = "Tenerife Norte (Los Rodeos)",symbol = "TFN",link = ""},

              new DataAirport(){city = "Анкона",name = "Ancona Falconara",symbol = "AOI",link = ""},
              new DataAirport(){city = "Бари",name = "Bari",symbol = "BRI",link = "http://www.aeroportidipuglia.it/default.asp?idlingua=2&idcontenuto=25"},
              new DataAirport(){city = "Бергамо",name = "Bergamo, Orio al Serio",symbol = "BGY",link = "http://www.orioaeroporto.it/en/"},
              new DataAirport(){city = "Венеция",name = "Venice, Marco Polo",symbol = "VCE",link = "http://www.veniceDataAirport.it/en/"},
              new DataAirport(){city = "Верона",name = "Verona, Villafranca",symbol = "VRN",link = "http://www.aeroportoverona.it/ru/passeggeri_t5/"},
              new DataAirport(){city = "Генуя",name = "Genoa, Cristoforo Colombo",symbol = "GOA",link = "http://www.aeroportodigenova.com/"},
              new DataAirport(){city = "Кальяри (Сардиния)",name = "Cagliari, Elmas",symbol = "CAG",link = "http://www.cagliari-DataAirport.com/"},
              new DataAirport(){city = "Катания (Сицилия)",name = "Catania, Fontanarossa",symbol = "CTA",link = "http://www.aeroporto.catania.it/?lang=en"},
              new DataAirport(){city = "Ламециа Терме",name = "Lamezia Terme, S Eufemia",symbol = "SUF",link = "http://www.lameziaDataAirport.it/"},
              new DataAirport(){city = "Милан",name = "Linate",symbol = "LIN",link = "http://www.milanolinate-DataAirport.com/en"},
              new DataAirport(){city = "Милан",name = "Malpensa",symbol = "MXP",link = "http://www.milanomalpensa-DataAirport.com/en"},
              new DataAirport(){city = "Неаполь",name = "Napoli, Capodichino",symbol = "NAP",link = "http://www.aeroportodinapoli.it/homepage"},
              new DataAirport(){city = "Палермо (Сицилия)",name = "Palermo, Punta Raisi",symbol = "PMO",link = "http://www.aeroporto.palermo.it/index.php?sezione=1&lang=en"},
              new DataAirport(){city = "Олбия (Сардиния)",name = "Olbia, Costa Smeralda",symbol = "OLB",link = "http://www.geasar.com/eng/DataAirport"},
              new DataAirport(){city = "Рим",name = "Leonardo da Vinci",symbol = "FCO",link = "http://www.adr.it/web/aeroporti-di-roma-ru-/home"},
              new DataAirport(){city = "Римини",name = "Federico Fellini",symbol = "RMI",link = "http://www.riminiDataAirport.com/"},
              new DataAirport(){city = "Триест",name = "Trieste Friuli Venezia Giulia",symbol = "TRS",link = "http://www.aeroporto.fvg.it/en/home/index.htm"},
              new DataAirport(){city = "Тревизо",name = "Treviso, Sant'Angelo",symbol = "TSF",link = "http://www.trevisoDataAirport.it/en/"},
              new DataAirport(){city = "Турин",name = "Turin, Citta Di Torino",symbol = "TRN",link = "http://www.aeroportoditorino.it/en"},
              new DataAirport(){city = "Флоренция",name = "Florence Peretola",symbol = "FLR",link = "http://www.aeroporto.firenze.it/en/"},
              new DataAirport(){city = "Форли",name = "Luigi Ridolfi",symbol = "FRL",link = "http://www.aviacom.it/"},

              new DataAirport(){city = "Актобе",name = "Aktobe",symbol = "AKX",link = "http://www.DataAirport-aktobe.kz/"},
              new DataAirport(){city = "Алматы",name = "Almaty",symbol = "ALA",link = ""},
              new DataAirport(){city = "Астана",name = "Astana",symbol = "TSE",link = ""},
              new DataAirport(){city = "Павлодар",name = "Pavlodar",symbol = "PWQ",link = ""},
              new DataAirport(){city = "Усть-Каменогорск",name = "Ust-Kamenogorsk",symbol = "UKK",link = ""},
              new DataAirport(){city = "Шымкент",name = "Shimkent",symbol = "CIT",link = ""},

              new DataAirport(){city = "Доха",name = "Doha International DataAirport",symbol = "DOH",link = "https://dohahamadDataAirport.com/"},

              new DataAirport(){city = "Ларнака",name = "Larnaca",symbol = "LCA",link = "https://www.hermesDataAirports.com/while-at-the-DataAirport/larnaka"},
              new DataAirport(){city = "Пафос",name = "Paphos",symbol = "PFO",link = "https://www.hermesDataAirports.com/while-at-the-DataAirport/paphos"},

              new DataAirport(){city = "Гонконг",name = "Hong Kong International",symbol = "HKG",link = ""},
              new DataAirport(){city = "Пекин",name = "Pekin, Beijing Capital",symbol = "PEK",link = ""},
              new DataAirport(){city = "Санья",name = "Sanya, Fenghuang",symbol = "SYX",link = ""},
              new DataAirport(){city = "Шанхай",name = "Shanghai Pudong",symbol = "PVG",link = ""},

              new DataAirport(){city = "Варадеро",name = "Varadero, Juan Gualberto Gomez",symbol = "VRA",link = ""},
              new DataAirport(){city = "Гавана",name = "Havana, Jose Marti Intl",symbol = "HAV",link = ""},

              new DataAirport(){city = "Порт Луи",name = "Sir Seewoosagur Ramgoolam",symbol = "MRU",link = "http://aml.mru.aero/"},

              new DataAirport(){city = "Мале",name = "Velana",symbol = "MLE",link = "http://www.macl.aero/"},

              new DataAirport(){city = "Канкун",name = "Cancun",symbol = "CUN",link = "http://www.asur.com.mx/en.html"},
              new DataAirport(){city = "Мехико",name = "Mexico",symbol = "MEX",link = "http://www.aicm.com.mx/en/"},

              new DataAirport(){city = "Абу Даби",name = "Abu Dhabi",symbol = "AUH",link = "http://www.abudhabiDataAirport.ae/english/"},
              new DataAirport(){city = "Дубай",name = "Dubai",symbol = "DXB",link = "http://www.dubaiDataAirports.ae/"},
              new DataAirport(){city = "Шарджа",name = "Sharjah",symbol = "SHJ",link = "http://www.sharjahDataAirport.ae/en/traveller/"},

              new DataAirport(){city = "Бухарест",name = "Henri Coanda",symbol = "OTP",link = "http://www.bucharestDataAirports.ro/en"},
              new DataAirport(){city = "Иаси",name = "Iasi",symbol = "IAS",link = "http://www.aeroport.ro/"},
              new DataAirport(){city = "Клуж-Напока",name = "Cluj Napoca",symbol = "CLJ",link = "http://DataAirportcluj.ro/"},
              new DataAirport(){city = "Тимишоара",name = "Timisoara",symbol = "TSR",link = "http://www.aerotim.ro/index.php?lang=en"},

              new DataAirport(){city = "Маэ",name = "Seychelles International",symbol = "SEZ",link = "https://seychellesDataAirports.sc/"},
              new DataAirport(){city = "Прале",name = "Praslin Island DataAirport",symbol = "PRI",link = ""},

              new DataAirport(){city = "Сингапур",name = "Singapore, Changi",symbol = "SIN",link = ""},

              new DataAirport(){city = "Бангкок",name = "Bangkok, Suvarnabhumi",symbol = "BKK",link = ""},
              new DataAirport(){city = "Краби",name = "Krabi",symbol = "KBV",link = ""},
              new DataAirport(){city = "Паттайя",name = "Pattaya, U-Tapao",symbol = "UTP",link = ""},
              new DataAirport(){city = "Пхукет",name = "Phuket",symbol = "HKT",link = ""},

              new DataAirport(){city = "Джерба",name = "Djerba-zarzis",symbol = "DLE",link = ""},
              new DataAirport(){city = "Монастир",name = "Monastir",symbol = "MIR",link = ""},
              new DataAirport(){city = "Тунис",name = "Tunisia, Carthage",symbol = "TUN",link = ""},

              new DataAirport(){city = "Алания",name = "Gazipasa",symbol = "GZP",link = "http://www.gzpDataAirport.com/en-EN/Pages/Main.aspx"},
              new DataAirport(){city = "Анталия",name = "Antalya",symbol = "AYT",link = ""},
              new DataAirport(){city = "Бодрум",name = "Bodrum",symbol = "BJV",link = ""},
              new DataAirport(){city = "Бурса",name = "Bursa",symbol = "BTZ",link = ""},
              new DataAirport(){city = "Бурса",name = "Yenisehir",symbol = "YEI",link = ""},
              new DataAirport(){city = "Даламан",name = "Dalaman",symbol = "DLM",link = ""},
              new DataAirport(){city = "Измир",name = "Izmir Adnan Menderes",symbol = "ADB",link = ""},
              new DataAirport(){city = "Стамбул",name = "Istanbul, Ataturk",symbol = "IST",link = "https://www.istDataAirport.com/en"},
              new DataAirport(){city = "Эрзурум",name = "Erzurum",symbol = "ERZ",link = "http://www.erzurum.dhmi.gov.tr/havaalanlari/home.aspx?hv=11"},

              new DataAirport(){city = "Лион",name = "Lion, St-Exupry",symbol = "LYS",link = ""},
              new DataAirport(){city = "Марсель",name = "Marseille Provence",symbol = "MRS",link = ""},
              new DataAirport(){city = "Ницца",name = "Nice Cote d'Azur",symbol = "NCE",link = ""},
              new DataAirport(){city = "Париж",name = "Charles de Gaulle",symbol = "CDG",link = ""},
              new DataAirport(){city = "Париж",name = "Orly",symbol = "ORY",link = ""},
              new DataAirport(){city = "Шамбери",name = "Chambery",symbol = "CMF",link = ""},

              new DataAirport(){city = "Дубровник",name = "Dubrovnik",symbol = "DBV",link = ""},
              new DataAirport(){city = "Пула",name = "Pula",symbol = "PUY",link = ""},

              new DataAirport(){city = "Подгорица",name = "Podgorica, Golubovci",symbol = "TGD",link = ""},

              new DataAirport(){city = "Брно",name = "Brno, Turany",symbol = "BRQ",link = ""},
              new DataAirport(){city = "Карловы Вары",name = "Karlovy Vary",symbol = "KLV",link = "http://www.DataAirport-k-vary.cz/ru/"},
              new DataAirport(){city = "Пардубице",name = "Pardubice",symbol = "PED",link = ""},
              new DataAirport(){city = "Прага",name = "Prague, Ruzyne",symbol = "PRG",link = ""},

              new DataAirport(){city = "Берн",name = "Berne, Belp",symbol = "BRN",link = ""},
              new DataAirport(){city = "Женева",name = "Geneva",symbol = "GVA",link = ""},
              new DataAirport(){city = "Цюрих",name = "",symbol = "ZRH",link = ""}
        };

        public void AddEntity()
        {
            foreach (var i in DataAirports)
            {
                var city = _context.cities.FirstOrDefault(model => model.name == i.city);
                Airport airport = new Airport()
                {
                    city = city,
                    name = i.name,
                    symbol = i.symbol,
                    link = i.link
                };
                _context.Airports.Add(airport);
            }
            _context.SaveChanges();
        }

        private class DataAirport
        {
            public string name { get; set; } = string.Empty;
            public string symbol { get; set; } = string.Empty;
            public string link { get; set; } = string.Empty;
            public string city { get; set; } = string.Empty;
        }
    }
}

