# LecturerManager – Plan implementacji

Plik iteracyjny dla AI. Każdy blok to jeden task do zlecenia.  
Przed każdym zadaniem AI powinien przeczytać `AGENTS.md` i odpowiednie pliki kontekstowe.

## Lista zadań do zrobienia

- [x] Mechanizm generowania serwisów i typów na podstawie definicji API.
- [x] Dodaj bootstrap do aplikacji angularowej.
- [x] Menu nawigacyjne.
- [x] Usuń liczbę zadań w tabeli kursów.
- [x] Strona z możliwością dodania nowych zajęć(Course).
- [x] Możliwość usuwania zajęć
- [x] Strona z możliwością dodania nowych zadań.
- [x] Na stronie z kursami po kliknięcu kursu przechodzi sie do strony kursu z listą zadań.
- [x] Strona kursu: na liście zadań obok zadania jest przycisk który usuwa zadanie.
- [x] Strona z kursami: po kliknięcu kursu przechodzi sie do strony z zadaniami.
- [x] Strona z zadaniami: po kliknięcu zadania przechodzi się do strony z elementami zadania.
- [x] Strona z elemantami zadania: na stronie jest przycisk, prowadzi on do strony gdzie można dodać element zadania (zdjęciowy albo tekstowy).
- [x] Strona z elemantami zadania: jest przycisk który umożliwia usuwanie elementu zadania.
- [x] Na stronach: kursów, zadań i elementach z zadań jest breadcrumb.
- [x] Domena i baza danych jest źle skonstruowana. AssignmentItem powinien zawierać tylko definicję jaka jest nazwa elementu i jaki typ. Powinienna być dodatkowa encja, która zawiera wypełniony przez studenta element zadania. Biznesowo to wygląda tak że nauczyciel definiuje zajęcia, zadania i element zadania, a student ma wypełnić elementy zadania zdefiniowane przez nauczyciela. Przykładowo: student wypełnia element zadania o typie tekstowym. Popraw domenę i bazę danych. Użytkowników narazie nie rób. Zastanów się czy nie zrobić osobnego bounded context. Na pewno powinieneś zrobić nową klasę w domenie zawierającą wysłanie elementu zadania przez studenta. Później zrób nową migrację bazy danych i zaktualizuj bazę.
