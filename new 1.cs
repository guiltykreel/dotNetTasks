class Car // объявление класса
{
  string color = "red"; // поле класса
}

class Person 
{
    public string name = "Undefined";   // имя
    public int age;                     // возраст
 
    public void Print() // метод (в данном случае, печатает в консоль параметры)
    {
        Console.WriteLine($"Имя: {name}  Возраст: {age}");
    }
}


// Наследование 



// Полиморфизм

public class Overload 	//перегрузка методов. все описанные методы имеют одно имя, 
						//одинаковый модификатор и тип, но разные типы аргументов (параметров)
  {
      public void DisplayOverload(int a){
          System.Console.WriteLine("DisplayOverload " + a);
      }
      public void DisplayOverload(string a){
          System.Console.WriteLine("DisplayOverload " + a);
      }
      public void DisplayOverload(string a, int b){
          System.Console.WriteLine("DisplayOverload " + a + b);
      }
  } 
  
  // свойства
  public class Point
  {
	  public int x;
	  public int y;
	  
	  public int Y
	  {
		  get // вернуть значение
		  {
			  return y;
		  }
		  set // положить значение
		  {
			  y = value; // attention!
		  }
	  }
  }
  
  class program
  {
	  Point.Y = 10; // присвоить значение полю y класса Point 
	  int y = Point.Y; // присвоить переменной y класса program значение поля y  сласса Point
	  
  }
  
  // статические поля
  
  public class MyClass
  {
	  public int a;
	  public static int b; //статическое поле. 
	  //можно инициировать значение как при объявляении так и вне класса
	 
	  public void SetB(int b)
	  {
		  this.b = b; // НЕ будет работать так как this ссылается на 
		  // поле конкретного экземпляра класса 
		  MyClass.B = b; // будет работать
	  }
	  
  }
  
  class program
  {
	  static void main(string[] args)
	  {
		  MyClass.b = 10; //обращение к статическому полю
		  
		  MyClass Class1  = new Class1();
		  Class1.a = 5;
		  
	  }
  }
  
  //статические методы
  статические методы класса могут работать только со статическими полями и методами
  но нестатические методы могут рабоатать со статическими полями и методами 
  
  //статический конструктор
  
  class MyClass()
  {
	  public MyClass()
	  {
		  Console.WriteLine("Конструктор");
	  }
	  static MyClass()
	  {
		  Console.WriteLine("Статический конструктор");
	  }
	  
  }