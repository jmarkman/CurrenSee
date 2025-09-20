# CurrenSee

This is a demo project to showcase supplementing traditional software development with GenAI tools such as Copilot.

## What is CurrenSee?

[FxRatesApi](https://fxratesapi.com/) is a web service that provides currency exchange rates. They offer a free tier that allows access to two endpoints: `/currencies` (a list of all active global currencies) and `/latest` (current exchange rates for a base currency and 1 or more quote currencies).

CurrenSee is a C# API wrapper library that wraps the FxRates API free tier endpoints so you can see currency exchange rates and active currencies. "CurrenSee". Get it? Tough crowd, Toriyama would've loved it for Dragon Quest.

## What's the GenAI part?

OpenAI published a simple standard to allow developers to write custom instructions not just its own AI agents, but for any AI agent. It leverages markdown files, and is hence called [AGENTS.md](https://agents.md/) (intentionally similar to README.md). 

[There are a lot of open source projects](https://github.com/search?q=path%3AAGENTS.md&type=code) using this pattern.

## Some ForEx terminology & factoids

Currency exchange rates are the backbone of foreign exchange (ForEx) trading. For this library, you'll only have to know a little bit about currency pairs.

A [currency pair](https://en.wikipedia.org/wiki/Currency_pair) is the relative value of one currency against another, and is written like `USD/JPY`.

The currency on the left side of the slash is called the "base currency", and the currency on the right side is called the "quote currency".

When you read a currency pair like `USD/JPY = 150.00`, it means that 1 US Dollar (USD) will be exchanged for 150 Japanese Yen.

[The ordering of currencies has established rules.](https://ftmo.com/en/how-is-base-currency-vs-quote-currency-defined-in-forex/) Currently, USD will always be on the left side of the slash *except* when paired with either EUR, GBP, AUD, or NZD.