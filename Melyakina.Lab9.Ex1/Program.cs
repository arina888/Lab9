//Вариант 10

//1.Проверить уникальность записей по свойству Name.*
//2.Найти покупателя с наименьшим возрастом.*
//3.Отсортировать заказы по City.*
//4.Переместить заказы, где Tag имеет значение "Компьютер", в отдельный список.*
//5.Сгенерировать новые случайные записи и добавить их в список, учитывая следующие условия: свойство Id должно быть итеративным, свойства ProductId, CustomerId, Phone, Email должны быть уникальными.

using System.Text;
using System.Text.Encodings;
using System.Text.Encodings.Web;
using System.IO;


var path = "Data Table.csv";
//Регистрация провайдера кодировок.
//  Делается один раз в приложении.
Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);

// Регистрация кодировки WINDOWS - 1251 для поддержки кирилицы.
Encoding encoding = Encoding.GetEncoding(1251);

var lines = File.ReadAllLines(path,encoding);
var datas = new Data[lines.Length - 1];

for (int i = 1; i < lines.Length; i++)
{
        var splits = lines[i].Split(';');
        
        var data = new Data();
        data.Id = Convert.ToInt32(splits[0]);
        data.Name = splits[1];
        data.Email = splits[2];
        data.Phone = splits[3];
        data.Age = Convert.ToInt32(splits[4]);
        data.City = splits[5];
        data.Street = splits[6];
        data.Tag = splits[7];
        data.Price = Convert.ToInt32(splits[8]);
        data.CustomerId = splits[9];
        data.ProductId = splits[10];
        
        datas[i - 1] = data;
}

// 1 задание

Console.WriteLine("Задание 1");
Console.WriteLine();

List<string> listName = new List<string>();
using (var reader = new StreamReader(path, encoding))
{
    while (!reader.EndOfStream)
    {
        var line = reader.ReadLine();
        var values = line.Split(';');

        listName.Add(values[0]);

    }
}

bool answ = listName.SequenceEqual(listName.Take(listName.Count()));
if (answ)
{
    Console.WriteLine("Записи по свойству Name уникальны");
}
else
{
    Console.WriteLine("Записи по свойству Name не уникальны");
}


// 2 задание

Console.WriteLine("Задание 2");
Console.WriteLine();

var min = datas.Min(x => x.Age);
Console.WriteLine(min);


// 3 задание

Console.WriteLine("Задание 3");
Console.WriteLine();

var sorteddata = from p in datas
                    orderby p.City
                    select p;

foreach (var p in sorteddata)
{ 
    Console.WriteLine(p);
}

// 4 задание

Console.WriteLine("Задание 4");
Console.WriteLine();


var selecteddatawithcomp = from i in datas
                           where i.Tag == "Компьютер"
                           select i;
foreach (var x in selecteddatawithcomp)
{
    Console.WriteLine(x);
}
Console.WriteLine();

// 5 задание

Random r = new Random();

char[] symbols = { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9', 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z', 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z' };
string[] emails = { "we3l08z5@gmail.com","i8ovxn2f@gmail.com","q4as80@outlook.com","opu@outlook.com","5iar3l8k@yandex.ru","4zegxla@mail.ru","8lf0g@yandex.ru","1zx8@yandex.ru","x@mail.ru","34d@gmail.com","o@outlook.com", "hr6zdl@yandex.ru", "kaft93x@outlook.com", "dcu@yandex.ru", "19dn@outlook.com", "pa5h@mail.ru", "281av0@gmail.com", "8edmfh@outlook.com", "sfn13i@mail.ru", "g0orc3x1@outlook.com", "rv7bp@gmail.com", "93@outlook.com" };
string[] names = {"Варвара Маслова","Даниэль Антонов","Софья Филатова","Глеб Фирсов","София Соколова","Светлана Орлова","Степан Токарев","Егор Андреев", "Ольга Абрамова", "Артём Галкин", "Валерия Смирнова", "Маргарита Лукьянова", "Елизавета Кошелева", "Таисия Медведева", "Пётр Иванов", "Артемий Назаров", "Вероника Лапина", "Ева Ушакова" };
string[] cities = { "Астрахань", "Москва", "Новосибирск", "Купино", "Орехов", "Хорлово", "Ртищево", "Светлоград", "Чебоксары", "Казань", "Уфа" };
string[] phones = { "(900)678-79-31", "(900)896-42-17", "(900)294-39-43", "(937)188-87-60", "(964)649-08-32", "(988)600-67-16", "(988)444-02-62", "(999)841-46-61", "(909)751-12-23", "(916)814-72-95", "(929)524-65-08", "(933)124-50-61" };
string[] streets = {"Рязанский проспект","улица Малый Арбат","Калужская улица","Московская улица", "улица Савушкина","Советская улица", "Миглинская улица", "Ленинская улица", "Центральная улица", "Зеленая улица", "Первомайский, переулок", "площадь Европы", "Кавказский бульвар", "Оборонная улица", "Павелецкая набережная" };
string[] tags = { "Кошелек", "Плащ", "Шарф", "Ножницы", "Кошелек", "Клатч", "Джинсы", "Мяч", "Стул", "Cтол", "Крем", "Носки", "Футболка", "Очки", "Холодильник", "Миксер", "Чайник" };
var customId = new List<string> ();
var productId = new List<string> ();

//генерируем случайные строки для customerId 
for (int s = 0; s < 10; s++)
{   string str = "";
    for (int i = 0; i < 10; i++)
    {
        var a = symbols[r.Next(0, symbols.Length)];
        str += a;
    } customId.Add(str);
  
}
//генерируем случайные строки для productId 

for (int g = 0; g < 10; g++)
{
    string stri = "";
    for (int o = 0; o < 10; o++)
    {
        var h = symbols[r.Next(0, symbols.Length)];
        stri += h;
    }
    productId.Add(stri);

}


using (var writer = new StreamWriter(path,true,encoding))

{
    for (int l = datas.Length+2; l < datas.Length+5; l++)
    {
        var NewRecord = new List<Data>()
        {
        new Data {Id = l ,Name = names[r.Next(0, names.Length)], Email = emails[r.Next(0, emails.Length)],Phone = emails[ r.Next(0,emails.Length)],Age = r.Next(14,70),City = cities[r.Next(0,cities.Length)],Street =streets[r.Next(0,streets.Length)],Tag = tags[r.Next(0,tags.Length)] ,Price =r.Next(100, 30000),CustomerId = customId[r.Next(0, customId.Count)],ProductId = productId[r.Next(0, productId.Count)]}
        };
        foreach (var n in NewRecord)
        {
            writer.WriteLine(n.ToExcel());
        }
    }
}      

public class Data
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public string Phone { get; set; }
    public int Age { get; set; }
    public string City { get; set; }
    public string Street { get; set; }
    public string Tag { get; set; }
    public int Price { get; set; }
    public string CustomerId { get; set; }
    public string ProductId { get; set; }

    

    public override string ToString()
    {
        return $"Id: {Id}\n Имя и фамилия: {Name}\n Электронный адрес : {Email}\n Номер телефона: {Phone}\n Возраст: {Age}\n Город: {City}\n Улица: {Street}\n Тэг:{Tag}\n Цена: {Price}\n Id покупателя: {CustomerId}\n Id товара: {ProductId}\n ";
    }
    public string ToExcel()
    {
        return $"{Id};{Name};{Email};{Phone};{Age};{City};{Street};{Tag};{Price};{CustomerId};{ProductId}";
    
    }
//    public void Display()
//{
//    Console.WriteLine(Id);
//    Console.WriteLine(Name);
//    Console.WriteLine(Email);
//    Console.WriteLine(Phone);
//    Console.WriteLine(Age);
//    Console.WriteLine(City);
//    Console.WriteLine(Street);
//    Console.WriteLine(Tag);
//    Console.WriteLine(Price);
//    Console.WriteLine(CustomerId);
//    Console.WriteLine(ProductId);

//}


}
