# Arkanoid_Hackathon_2024_Vologda

Жанр: Arkanoid
Arkanoid - игра, изначально разработанная в 1986 году для игровых автоматов.

Суть игры. В игре игрок должен управлять небольшой платформой-ракеткой, которую можно передвигать горизонтально от одной стенки до другой, подставляя её под шарик, чтобы он не упал вниз. С противоположной стороны расположены блоки-кирпичи. Удар шарика по блоку-кирпичу приводит к его разрушению. После того как все блоки на уровне уничтожены, происходит переход на следующий уровень, с новым набором блоков.

Возможные вариации геймплея. Некоторые блоки нужно ударять несколько раз для разрушения, летающие блоки, бонусы.

Примеры игр

http://arkanoide.ru/igra-arkanoid/

http://arkanoide.ru/kosmicheskoe-prostranstvo/



### Задание
Вам необходимо создать прототип игры в жанре Arkanoid с использованием примитивов или готовых ассетов.
В игре должно быть меню и базовый игровой графический интерфейс.

### Требования
Реализованы все ключевые механики игры Arkanoid:
- [x] Каретка, управляемая игроком;
- [x] Шарик, перемещающийся по игровому полю и отскакивающий от стенок, каретки и блоков;
- [ ] Разрушаемые блоки;
- [ ] Поражение в игре при выходе шарика за пределы игрового поля.
- [ ] Реализована одна любая дополнительная игровая механика;
- [x] Игра должна запускаться на платформе Windows в полноэкранном режиме;
- [x] Управление осуществляется с помощью клавиатуры / мыши;
- [ ] Присутствует подсказка или инструкция по управлению.

#### Ждем ваши игровые билды ссылкой на Git. Не забудьте сделать доступ к файлам публичным.
 

Критерии оценки и требования
Общее требования прописаны в Положении к Хакатону, если иное не прописано в требованиях к заданию в Техническом задании.

## Максимальное количество баллов — 30.
### Общее качество реализации (10 баллов):
- отсутствие критических ошибок, прерывающих или нарушающих игровой процесс;
- корректная работа со временем, отсутствие зависимости от количества кадров в секунду;
- возможность возобновить игровой процесс после поражения или победы.

### Качество реализации механик (10 баллов):
- понятное и отзывчивое управление кареткой;
- корректная работа с физикой шарика;
- разрушение блоков и реакция шарика соответствуют игровой логике оригинала;
- ограниченное количество попыток до наступления поражения;
- реализована дополнительная игровая механика.

### Реализация UI и его адаптивность (10 баллов):
- отображена информация о текущем состоянии игры: номер этапа игры, сумма набранных очков, оставшееся количество жизней или другая необходимая игроку информация;
- наличие меню победы и поражения;
- отсутствие ошибок в логике работы графического интерфейса;
- корректная верстка графического интерфейса под разные разрешения экранов;
- отсутствие искажения пропорций элементов графического интерфейса.
