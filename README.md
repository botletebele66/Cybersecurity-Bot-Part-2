# Cybersecurity Bot – Part 2

A modular cybersecurity assistant for automated threat intelligence, log analysis, and incident response.  
This is the second iteration, adding enhanced modules and a CI/CD pipeline.

## Features
- **Threat Intel** – Query VirusTotal, AlienVault OTX, Shodan
- **Log Analysis** – Parse syslog, auth.log, Windows Event Logs
- **Incident Response** – Playbooks for phishing, brute force, malware
- **Alerting** – Slack, email, webhook notifications
- **Plugin System** – Extend with custom analyzers and responders

## Getting Started

### Prerequisites
- Python 3.9+
- `pip` and `virtualenv`

### Installation
```bash
git clone https://github.com/botletebele66/Cybersecurity-Bot-Part-2.git
cd Cybersecurity-Bot-Part-2
python -m venv venv
source venv/bin/activate   # Windows: venv\Scripts\activate
pip install -r requirements.txt
cp .env.example .env        # fill in your API keys
