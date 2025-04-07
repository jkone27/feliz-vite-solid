import solid from "vite-plugin-solid"
import { defineConfig } from "vitest/config"
import existingConfig from "./vite.config"

const createTestConfig = { ...existingConfig, resolve: {
    conditions: ["development", "browser"],
    test: {
      server: {
        deps: { inline: true }
      }
    }
  }
};

export default defineConfig(createTestConfig)