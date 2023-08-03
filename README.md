#Task Marketplace
## Поставнока задачи
**Цель** - разработать маркетплейс для размещения платных заданий для разработчиков  
  
**Действующие лица**:
1. Администратор - управляет контентом маркетплейса:
   - Размещает новые задания
   - Принимает выполненные задания, либо оставляет замечания
3. Участник - выполняет задания:
   - Регистрируется в системе
   - Просматривает список заданий и их содержимое
   - Отправляет вариант своего решения на проверку
  
**Дополнительные условия**:
  - Задания имеют ограничения по времени
  - Варианты решения принимаются до окончания срока действия задания
  - Принятием решения считается подтверждения от администратора
  - Администратор может "принять" любое количество решений
  - Принятием решения считается подтсверждение о администратора

## Инструменты для реализации
Проект написано на *C#* с помощью паттерна *ASP.NET MVC* и *Entity Framework Core* для работы с базой данных. БД - *SQL Server*. Для реализации авторизации пользователей была использована встроенная в проект Identity.
Для написания внешнего вида сайта были использованы шаблоны *Bootstrap*.
