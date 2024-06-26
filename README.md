# Веб-служба (вебхук) для получения данных с сервиса Яндекс.Расписаний
Эта веб-служба (вебхук) упрощает взаимодействие с сервисом "Яндекс.Расписания" ООО "Яндекс" посредством приёма и обратной передачи списков гражданских авиарейсов. Преимуществом данного программного обеспечения является лёгкость интеграции со смежными кодовыми базами. Под этим текстом Вы обнаружите краткую документацию функционала программы.
## Работа с программой
В качестве фронтенда (пользовательского интерфейса службы) используется библиотека Swagger UI. Для совершения запроса к веб-службе необходимо:

1. Открыть/развернуть панель запроса (синий контейнер)
2. Нажать кнопку `Try it out`
3. Заполнить поля тела запроса в соответствии с документацией (этот файл)
4. Нажать `Execute`
5. Решить, что делать с результатом (парсинг, передача в брокер и т.д.)

### Описание панелей запроса

#### `get-airport`
Получение списка всех рейсов из базы данных.

Параметров не имеет.

#### `get-airport`
Получение списка рейсов по кодам ИАТА пунктов назначения и отправления.

__`from`__ - код ИАТА пункта отправления

__`to`__ - код ИАТА пункта назначения


#### `get-date`
Получение списка рейсов по кодам ИАТА пунктов назначения и отправления, а также дате прибытия.

__`from`__ - код ИАТА пункта отправления

__`to`__ - код ИАТА пункта назначения

__`date`__ - дата прибытия рейса, выраженная в формате `ГГГГ-ММ-ДД`


_Код ИАТА - специальное трёхбуквенное обозначение гражданских аэропортов, используемых Международной ассоциацией воздушного транспорта._

## Лицензиорвание
Данный программный продукт является общественным достоянием. Иными словами, делайте с ним что хотите.
