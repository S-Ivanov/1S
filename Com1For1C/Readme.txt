Соответствие типов:
C# (COM)	<->		1С
int					Число
double				Число
DateTime			Дата
string				Строка
?					Булево
object				?
int[]				Array (C#)	-	COM-объект, эквивалентный классу System.Array ([ComVisibleAttribute(true)])
									Доступ к значениям через методы GetValue(...) и SetValue(...)
									Свойства читаются через Get-методы, например, вместо Length - GetLength()
string[]			Array (C#)