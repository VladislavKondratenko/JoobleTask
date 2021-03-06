## JoobleTask

Немецкий язык богат составными (сложными) словами, т.е. словами, состоящими из двух или более простых слов.
Требуется написать консольную утилиту, которая получит на вход набор слов для обработки, и разобьет составные слова на части.
Постановка задачи
1.	Утилита принимает на вход путь к файлу(в котором будет набор слов для обработки), а также путь к файлу для записи результатов..
2.	Реализовываем алгоритм, который используя словарь базовых слов, умеет разбивать составные слова на части, если это возможно..
3.	Утилита обрабатывает входные слова алгоритмом выше, и записывает результат в файл, в следующем формате:
(in) psychologie -> (out) psychologie // слово, которое невозможно разбить
(in) krankenhaus ->  (out) kranken, haus // слово которое смогли разбить
При реализации алгоритма, следует брать из словаря, максимально “длинное” слово, насколько это возможно.

К примеру если у нас словарь состоит из слов: [ krank, en, kranken, haus ], то возможны несколько вариантов:

krankenhaus -> kranken, haus // правильное разбиение
krankenhaus -> krank, en, haus // неправильное разбиение
Словарь со словами немецкого языка: https://drive.google.com/file/d/1qzd2wCN2FgUSjyj78h6FxKlwwUr-NZTK/view?usp=sharing

Набор слов для обработки: https://drive.google.com/file/d/1m87FG1WRVQqsJiiNCcWtrgjTCDUGbwft/view?usp=sharing
Основные требования
1.	Читаемый и понятный код
2.	Простота реализации
3.	Производительность алгоритма разбиения (чем быстрее, тем лучше)
Результаты можно заливать на github, либо отправив нам архив с кодом
Срок выполнения: до 5 дней.
