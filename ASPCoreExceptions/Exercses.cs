/*
1. Przygotuj własny wyjątek reprezentujący sytuację, w której została przekazana ocena produktu spoza zakresu <1,5>.
Powinien posiadać dwie niestandardowe właściwości:
- udzielana ocena (int),
- ID użytkownika, który próbuje udzielić niepoprawnej odpowiedzi (int).     
Przygotowany wyjątek rzuć w dowolnej akcji kontrolera z ustaionymi na sztywno wartościami i obsłuż go
w taki sposób, żeby pomimo niego wyświetlił się widok, a bład został zalogowany w logerze

2.Przygotuj własny middleware logujący czasy obsługi żądań.
W logu powinna pojawić się ścieżka wywołania oraz czas (w ms), w którym żądanie zostało obsłużone.
Do mierzenia czasu skorzystaj z klasy Stopwatch.

3.Przygotuj własny wyjątek reprezentujący sytuację, w której przetwarzanie żądania trwa zbyt długo.
Powinien posiadać jedną niestandardową właściwość: czas przetwarzania żądania (int, w ms).
Rozbuduj middleware zrobiony w zadaniu nr 2 w taki sposób, żeby wyjątek dodany w pierwszej części zadania 3
był rzucany, jeśli czas przetwarzania żądania przekracza 1000 ms.
Do symulacji dłuższego czasu przetwarzania możesz skorzystać z metody Thread.Sleep().
Obsłuż taki wyjątek i dodaj do logów informację o jego wystąpieniu (razem z czasem obsługi żądania).
 */

