# UsersTodosAndPosts

Данное приложение представляет собой программу на c# (NET Core Web API), которая будет формировать сводку действий пользователя на основе данных из API.
Источник данных: JSON REST API https://jsonplaceholder.typicode.com/

Доступны следующие методы:
- список пользователей: https://jsonplaceholder.typicode.com/users
- список дел: https://jsonplaceholder.typicode.com/todos
- список постов: https://jsonplaceholder.typicode.com/posts

Программа на вход получает id пользователя (через Swagger), и выполняет следующее:
1) собирает список завершённых дел этого пользователя
2) собирает 5 последних постов этого пользователя (предполагаем, что более свежие посты имеют более высокий id)
3) формирует текст со следующим содержанием:
Уважаемый {user name},
ниже представлен список ваших  действий за последнее время.
Выполнено задач:
{перечисление всех выполненных задач из todos, текст из поля title}
Написано постов:
{перечисление всех выполненных задач из posts, текст из поля title}

4) сохраняет его в виде текстового файла на диск, путь к папке для хранения файлов указывается в конфиге приложения (appsettings.json).
