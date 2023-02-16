# Workshop for Sikkerhetsakademiet
Dette er en enkel webapplikasjon som er laget for å at du som utviklere skal få litt mer erfaring med sikker utvikling, med andre ord denne web applikasjonen er ikke trygg og må sikres!

## Getting started.
Prosjektet er et .NET7 prosjekt, du skal kunne starte det opp lokalt enkelt fra Visual Studio eller IDEen du bruker for .NET-løsninger.

Løsningen har swagger tilgjenglig for å komme dit skriver du bare inn '/swagger' og trykker enter.


## Oppgave 1: HTTPS
Alle appliksjoner som er laget for web bør nekte å la tjenester koble seg til over HTTP. Din oppgave er derfor å sørge for at applikasjonen kun tillater tilkobling over HTTPS.
 

## Oppgave 2: HTTP Headers
For å sikre at man ikke gir bort mer informajon enn nødvendig og at en del beskyttelsestiltak er på plass bør vi settes HTTP Security Headers i koden. 

OWASP har mer informasjon om dette her https://owasp.org/www-project-secure-headers/

Din oppgave:
1. Legg til de viktigste headerene Content-Security Policy (CSP), Permission-Policy, Strict-Transport Secutiry (HSTS), Referrer-Policy og X-Content-Type-Options.
2. Legg til flere headere som du mener trengs gjerne basert på OWASP sine anbefalinger
3. Fjern headere som røper informasjon 

## Oppgave 3: Information Disclousre
Denne webapplikasjonen røper mer informasjon enn den bør for en eventuelt angriper. Kan du fikse det?

1. For å gjenskape feilen poster du et skjema to ganger med samme ID og ser hva som skjer
2. Sørg for at stack traces ikke vises og at feil håndteres på en fornuftig måte.

## Oppgave 4: Håndtering av input (XSS)
Kan du finne XSS i skjemaet?
Har du funnet den så fiks den!

Eksempler:
````<script>alert(1)</script> ````
````<img src='1' onerror='alert("Error loading image")'>```

## Oppgave 5: Håndtering av input (SQL injection)
Kan du finne en SQL injection i løsningen?
Sørg for at denne SQL-injection ikke er mulig.

## Oppgave 6: SQL injection blind
Klarer du å finne en SQL injection til?
Sørg for at denne SQL-injection ikke er mulig.

## Oppgave 7: XXE
Kan du finne XXE i skjemaløsningen?
Sørg for at XXE ikke er mulig

Eksempel            
````<?xml version="1.0" encoding="UTF-8"?><!DOCTYPE message><message>Hello from me</message>````

## Oppgave 8: SSRF
Kan du finne SSRF i skjemaløsningen?
Sørg for at SSRF ikke er mulig


## Oppgave 9: Lag en security-fil
Dersom prosjektet er open-source bør det inneholde en security.md fil som forteller hvilke versjoner som støttes av sikkerhetsoppdateringer samt hvordan sikkerhetsutfordringer/hull skal rapporteres. Er prosjektet kommersielt bør du legge til en security.txt fil tilsvarende som Google
har https://www.google.com/.well-known/security.txt 

## Oppgave 10: Håndtering av HTTP POST kan være sårbar for CSRF
Hvordan kan et skjema være sårbart for CSRF?
Kan du fikse slik at skjemaet ikke er sårbart for CSRF?
