# RegTest
Программа выполняет построение недетерминированного конечного автомата по заданному регулярному выражению(академическому). Предстваляет результат в виде графа и таблицы переходов. ПО производит обработку введенных цепочек с помощью построенного НКА.

## Можно использовать при вводе определенные операции: 
  * {a} - итеративные скобки;
  * a|b - или;
  * ab - простая конкатенация.
К примеру выражение **{a|b|c}cab{a|b|c}** - все строки которые содержат подстроку **cab** - **aababababaabcabababababa**, **aaaacabbbb**

## Обработка введенных данных
  После построения НКА нижнее текстовое поле станет активным и туда можно будет вводить данные. Чтобы вычислить принадлежит ли введенная цепочка языку распознаваемому автоматом. Результаты представляются в виде **True**,**False** так же указано время обработки. ПРи обработке используется два вида НКА первый классический второй является многопоточной реализацией. Так же ПО отрисовывает граф потока обработки.  

