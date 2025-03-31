import { defineConfig } from 'vite'
import solid from 'vite-plugin-solid'
import fable from "vite-plugin-fable"
import { configDefaults } from "vitest/config";

export default defineConfig({
  plugins: [
    fable({
      fsproj: "./src/App.fsproj",
      jsx: 'preserve'
    }),
    solid({ 
      extensions: ['.fs', '.tsx', '.jsx', '.js', '.ts']
    }),
  ],
  root: "./src",
  build: {
    outDir: "../dist",
    sourcemap: "inline",
    target: "esnext"
  },
  define: {
    // required if u have: `process is undefined`
    // while loading react jsoncomponents
    "process.env": {},
  },
  test: {
    include: ["**/*.{test,spec}.{js,jsx,ts,tsx,fs}"],
    exclude: [...configDefaults.exclude, "dist", ".idea", ".git", ".cache"],
    environment: "jsdom",
    setupFiles: "../vitest.ts",
    transform: {
      "^.+\\.fs$": "vite-plugin-fable",
    },
  },
});
