++++++++++++++++# Launchbox_Shortcut
Shortcut Plugin für LaunchBox/BigBox


# Installation des Proxmox Servers

# Pissa
***ok***

**Schritt 1: Proxmox ISO-Image herunterladen**

1. Besuchen Sie die offizielle Proxmox-Website, um das aktuelle ISO-Image herunterzuladen: [https://www.proxmox.com/proxmox-ve](https://www.proxmox.com/proxmox-ve)

**Schritt 2: Rufus herunterladen und vorbereiten**

1. Gehen Sie zur offiziellen Rufus-Website und laden Sie das Rufus-Tool herunter: [https://rufus.ie/](https://rufus.ie/)
2. Installieren Sie Rufus auf Ihrem Computer.

**Schritt 3: USB-Boot-Stick erstellen**

1. Starten Sie Rufus.
2. Stecken Sie einen leeren USB-Flash-Laufwerk mit ausreichend Speicherplatz (mindestens 8 GB) in Ihren Computer.
3. Wählen Sie in Rufus das angeschlossene USB-Laufwerk unter "Gerät" aus.
4. Wählen Sie unter "Boot-Auswahl" das zuvor heruntergeladene Proxmox ISO-Image aus, indem Sie auf "Auswählen" klicken.
5. Lassen Sie die übrigen Einstellungen in Rufus unverändert und klicken Sie auf "Start".
6. Rufus wird Sie warnen, dass alle auf dem USB-Laufwerk vorhandenen Daten gelöscht werden. Bestätigen Sie diese Meldung, wenn Sie sicher sind, dass Sie alle wichtigen Daten gesichert haben.
7. Rufus wird das Proxmox ISO-Image auf den USB-Stick schreiben und den USB-Boot-Stick erstellen.

**Schritt 4: Proxmox auf dem Zielserver installieren**

1. Schalten Sie den Zielserver ein oder starten Sie ihn neu.
2. Booten Sie den Server von Ihrem erstellten USB-Boot-Stick. Dies erfordert normalerweise eine Anpassung der BIOS/UEFI-Einstellungen, um von USB zu booten. Konsultieren Sie die Dokumentation Ihres Servers für spezifische Anweisungen.
3. Der Proxmox-Installer wird gestartet. Befolgen Sie die Anweisungen auf dem Bildschirm, um Proxmox auf Ihrem Server zu installieren.
4. Während der Installation werden Sie aufgefordert, Administratorinformationen einzugeben, einschließlich des Root-Passworts und anderer Netzwerkkonfigurationen.
5. Nach Abschluss der Installation können Sie auf die Proxmox-Oberfläche über einen Webbrowser zugreifen. Verwenden Sie die IP-Adresse Ihres Proxmox-Servers, um auf die Weboberfläche zuzugreifen (z. B. https://&lt;Ihre\_Server\_IP&gt;:8006).

**Schritt 5: Konfiguration von Proxmox**

1. Melden Sie sich mit den zuvor festgelegten Administratorinformationen an der Proxmox-Webkonsole an.
2. Konfigurieren Sie Ihr Proxmox-System gemäß Ihren Anforderungen, indem Sie virtuelle Maschinen und Container erstellen und verwalten.

[![image.png](https://docs.robinthor.de/uploads/images/gallery/2024-04/scaled-1680-/image.png)](https://docs.robinthor.de/uploads/images/gallery/2024-04/image.png)

Als letztes macht mal ein volles Update:

'''bash
TEST -
'''
```powershell
GetAppx
```
```bash
apt update && apt upgrade -y
```
