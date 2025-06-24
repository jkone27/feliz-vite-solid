# Vite Feliz Solid ⚡️

![CI](https://github.com/jkone27/feliz-vite-solid/actions/workflows/ci.yaml/badge.svg)

![vite feliz solid in action](image.png)

A template for writing your next [Solid-js](https://solidjs.com) app in [F#](https://dotnet.microsoft.com/en-us/languages/fsharp) with seamless [vite](https://vite.dev/guide/) integration.

## Feliz

Write your F# app using [Feliz.JSX.Solid](https://github.com/fable-compiler/Feliz.JSX) and [Feliz DSL](https://zaid-ajaj.github.io/Feliz/).  

## Setup (.NET +  F#)

* install latest [dotnet-sdk](https://dotnet.microsoft.com/en-us/), e.g. on mac `brew install dotnet-sdk`.  
* install [ionide extension](https://ionide.io/) for vs-code or [the vim extension](https://github.com/ionide/Ionide-vim), other F# enabled editors like JB Rider or MSVS support F# natively as well and offer free community versions. 

## Go 👨🏽‍🔧

```bash
> npm i  
> npm run test
> npm run dev
```

Or use [bun](https://bun.sh/) it's blazing fast!

## How does this all work? 🐉

Thanks to the awesome [vite-plugin-fable](https://fable.io/vite-plugin-fable/), check it out and contribute or join [F# discord](https://discord.com/channels/196693847965696000/196695876054286336).

### Trick for vitest in solidjs

had to be aware of this [server inline trick](https://github.com/vitest-dev/vitest/discussions/6537) in [vitest.config.ts](./vitest.config.ts)
