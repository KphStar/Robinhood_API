# Crypto Watching: Live Bitcoin Dashboard

## Overview

**Crypto Watching** is a real-time Bitcoin price monitoring desktop application built with **C#** and **Windows Forms**. Designed for personal use, this dashboard visualizes live BTC price movements using data fetched from the (unofficial) Robinhood Crypto API. The app features a modern UI, a price/time chart, and a realistic Bitcoin background, giving you a quick and engaging way to watch the crypto market.

Key features:
- **Live BTC Price Updates:** Fetches and displays live Bitcoin price (BTC-USD) from Robinhood’s crypto market endpoint.
- **Interactive Chart:** Plots BTC price over time with auto-scaling and interactive mouse-hover for precise value inspection.
- **Modern UI:** Large, readable display with real-time clock, current price, and a visually striking Bitcoin background.
- **Secure API Access:** Uses Ed25519 key signatures for secure communication with the Robinhood API (see *Note* below).
- **Easy Exit:** Cleanly closes with a single click.



> **Note:**  
> This application uses an *unofficial* Robinhood API for personal or educational use only.  
> You must supply your own Robinhood API key and Ed25519 private key to access the crypto endpoints.  
> Handle all keys and credentials securely—never upload secrets to public repositories.

---

## Features

- **Live BTC/Price Streaming:** Updates every second using Robinhood’s `/crypto/marketdata/best_bid_ask` endpoint.
- **Ed25519 Authentication:** Secure API calls with BouncyCastle for message signing.
- **Charting:** Smooth, auto-scaling chart using Windows Forms built-in chart controls, with marker dot and price info on hover.
- **Customizable UI:** Transparent chart background overlays a high-res Bitcoin image for a polished look.
- **Exit Button:** Simple exit functionality for user convenience.

---

## Usage

1. **Clone this repository** and open the solution in Visual Studio.
2. **Provide your API keys and private key file** by updating the `keyPath`, `privateKeyFile`, and `robinhoodApiKey` fields in `Form1.cs`.
3. **Run the app**—you’ll see the live Bitcoin price and chart update in real time.

---

## Disclaimer

This project is **not affiliated with Robinhood Markets, Inc.**  
Use for learning, personal dashboards, or prototyping only.  
**Never share your keys or upload secrets to public code repositories.**

---

## Screenshot

![Live Bitcoin Dashboard](BTC_Result.png)
---

## License

MIT License. See [LICENSE](LICENSE) for details.
