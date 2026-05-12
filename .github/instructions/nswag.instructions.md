---
description: "Use when working with the Angular frontend API client. Covers NSwag auto-generation rules and how to update api.ts."
applyTo: "lecturer-manager-frontend/src/app/api/api.ts"
---

# Zasada: api.ts jest plikiem AUTO-GENEROWANYM

Plik `lecturer-manager-frontend/src/app/api/api.ts` jest **automatycznie generowany** przez NSwag na podstawie definicji OpenAPI z backendu.

**NIGDY nie edytuj tego pliku ręcznie.** Wszelkie ręczne zmiany zostaną nadpisane przy kolejnej regeneracji.

## Jak zaktualizować api.ts

Gdy backend się zmienia (nowe endpointy, zmienione DTO, itp.), należy zregenerować klienta:

1. Uruchom API:
   ```
   dotnet run --project LecturerManager.Api/LecturerManager.Api.csproj
   ```
2. Poczekaj aż API nasłuchuje na `http://localhost:5268`
3. W folderze frontendu wygeneruj klienta:
   ```
   cd lecturer-manager-frontend
   npm run generate:api
   ```
4. Zatrzymaj API.

Źródło schematu: `http://localhost:5268/openapi/v1.json`  
Wyjście: `src/app/api/api.ts`
