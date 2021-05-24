# SJ Buzzer

Small program to query the Playstation2 buzzers.

## Third Party Libraries

SharpDX - SharpDX is an open-source managed .NET wrapper of the DirectX API.<br/>
[GitHub SharpDX](https://github.com/sharpdx/SharpDX) | [Homepage SharpDX](http://sharpdx.org)

-----

## Beschreibung
"SJ Buzzer" ist ein kleines Programm zum Abfragen der Playstation2-Buzzer. Somit kann man mit diesem Programm ein eigenes Quiz, z.B. der Große Preis, in gemütlicher Runde veranstalten.

## Voraussetzungen
  * Betriebssystem: Windows
  * [NET Framework 4.8](https://dotnet.microsoft.com/download/dotnet-framework/net48)
  * Set der Playstation2-Buzzer (1 Set = 4 Spieler, 2 Sets = 8 Spieler)

## Treiber-Einstellungen für die Playstation-Buzzer
Schliesst man die Buzzer am PC an, so erkennt Windows auch ein Gerät und versucht einen Treiber zu installieren. Die Installation schlägt fehl, da es ja keinen Treiber gibt. Dummerweise ordnet Windows 7 die Buzzer nun als nicht funktionierenden USB-Hub ein. Mit dieser Einstellung ist es aber nicht möglich die Buzzer abzufragen. Die Buzzer müssen so konfiguriert werden das sie als HID (Human Interface Device) erkannt werden.

Folgende Schritte sind dafür nötig:

  1. Den Gerätemanager aufrufen.
  2. Mit rechte Maustaste auf den **USB-Hub** klicken und im Kontextmenü **"Treibersoftware aktualisieren…"** auswählen.
  3. Den Punkt **"Auf dem Computer nach Treibersoftware suchen"** starten.
  4. Den Punkt **"Aus einer Liste von Gerätetreibern auf dem Computer auswählen"** starten.
  5. Aus der Liste den Eintrag **USB-Eingabegerät** (HID) markieren.
  6. Mit dem Button **Weiter** die Installation abschliessen.

Sollte alles funktioniert haben, so findet man den Buzzer als Gamecontroller im Windows.

## Änderungen
  * **20.04.2012:** Start der Programmierung
  * **24.05.2021:** Entfernung von DirectX. Ersetzt durch [SharpDX](http://sharpdx.org).
  * **25.05.2021:** Upload auf GitHub.
