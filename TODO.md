# LecturerManager – Plan implementacji

Plik iteracyjny dla AI. Każdy blok to jeden task do zlecenia.  
Przed każdym zadaniem AI powinien przeczytać `AGENTS.md` i odpowiednie pliki kontekstowe.

## Lista zadań do zrobienia

### Wstępne

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

### Użytkownicy: nauczyciel i studenci

- [x] Encja `User` (login, hash hasła, poszczególne pola danych osobowych zaszyfrowane osobno (będą szyfrowane a potem kodowane base64 na frontendzie): imię, nazwisko, indeks, email). Konto nauczyciela hardcodowane (brak rejestracji nauczyciela).
- [ ] Rejestracja studenta: strona rejestracji z formularzem (signal forms). Szyfrowanie danych osobowych: każde pole (imię, nazwisko, indeks, email) szyfrowane osobno algorytmem RSA-OAEP (SHA-256, klucz 2048-bit) kluczem publicznym przez Web Crypto API przed wysłaniem; wynik kodowany jako Base64; backend przechowuje zaszyfrowane pola jako tekst.
- [ ] Logowanie studenta: endpoint logowania zwracający JWT z rolą; strona logowania.
- [ ] Logowanie nauczyciela: pozwól na logowanie się nauczyciela, konto nauczyciela jest tylko jedno, zaproponuj użytkownikowi opcję jak to zrobić i daj mu zdecydować którą opcję chce.
- [ ] Routing i autoryzacja: route guards dla ról (`teacher`, `student`), routing `/teacher/...` i `/student/...`, przeniesienie istniejących widoków do panelu nauczyciela.
- [ ] Panel studenta (`/student/...`): przeglądanie kursów, zadań i elementów zadań; student może wielokrotnie wysyłać i poprawiać wypełnione elementy. Zastanów się jak to zrobić dobrze w ddd bo mamy bounded context coursemanagment, czy to wymaga refaktoru, czy jak to zrobić zapytaj użytkownika.
- [ ] Lista studentów: endpoint zwracający zaszyfrowane pola danych osobowych (Base64); widok w panelu nauczyciela wyświetlający zaszyfrowany tekst; skrypt w Tampermonkey będzie odszyfrowywał pola za pomocą klucza prywatnego RSA (PKCS#8) przez Web Crypto API (RSA-OAEP, SHA-256). W jakiś sposób musisz oznaczać że dane pola mają być odszyfrowane, zaproponuj kilka opcji i daj użytkownikowi wybór.

### Wysyłanie zadań przez studenta

- [ ] Student może wysłać wypełnione elementy zadania (tekst lub zdjęcie) dla wybranego zadania.
- [ ] Student widzi potwierdzenie lub błąd po wysłaniu.

### Sprawdzanie zadań przez nauczyciela (ocenianie)

- [ ] Nauczyciel może przyznać punkty za element zadania każdemu studentowi, który go wysłał.
- [ ] Po przyznaniu punktów jednemu studentowi system automatycznie pokazuje odpowiedź kolejnego.
- [ ] Gdy wszyscy studenci zostali ocenieni, nauczyciel widzi stosowny komunikat.

