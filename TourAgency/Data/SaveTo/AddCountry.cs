using System;
namespace TourAgency.Data.SaveTo
{
    public class AddCountry
    {
        private AppDbContext _context;
        public AddCountry(AppDbContext context)
        {
            _context = context;
        }
        private static List<List<string>> countries = new List<List<string>>()
        {
            new List<string>() { "Барбадос", "Barbados"},
            new List<string>() { "Вьетнам", "Vietnam"},
            new List<string>() { "Греция", "Greece"},
            new List<string>() { "Доминикана", "Dominican Republic"},
            new List<string>() { "Индонезия", "Indonesia"},
            new List<string>() { "Испания", "Spain"},
            new List<string>() { "Италия", "Italy"},
            new List<string>() { "Кабо-Верде", "Cape Verde"},
            new List<string>() { "Камбоджа", "Cambodia"},
            new List<string>() { "Катар", "Qatar"},
            new List<string>() { "Кипр", "Cyprus"},
            new List<string>() { "Китай", "China"},
            new List<string>() { "Куба", "Cuba"},
            new List<string>() { "Маврикий", "Mauritius"},
            new List<string>() { "Малайзия", "Malaysia"},
            new List<string>() { "Мальдивы", "Maldives"},
            new List<string>() { "Мексика", "Mexico"},
            new List<string>() { "ОАЭ", "UAE"},
            new List<string>() { "Россия", "Russia"},
            new List<string>() { "Сейшелы", "Seychelles"},
            new List<string>() { "Сингапур", "Singapore"},
            new List<string>() { "Тайланд", "Thailand"},
            new List<string>() { "Филиппины", "Philippines"},
            new List<string>() { "Франция", "France"},
            new List<string>() { "Хорватия", "Croatia"},
            new List<string>() { "Шри Ланка", "Sri Lanka"},
            new List<string>() { "Ямайка", "Jamaica"},
        };
        public void AddEntity()
        {
            foreach (var i in countries)
            {
                _context.Countries.Add(new Models.Country() {
                    name = i[0],
                    flag = i[1]
                });
            }
            _context.SaveChanges();
        }
    }
}

