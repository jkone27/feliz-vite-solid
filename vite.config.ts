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
  test: {
    include: ["**/*.{test,spec}.{js,jsx,ts,tsx,fs}"],
    exclude: [...configDefaults.exclude, "dist", ".idea", ".git", ".cache"],
    environment: "jsdom",
    server: {
      deps: { inline: true }
    }
  }
});
