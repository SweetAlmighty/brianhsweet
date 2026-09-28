import react from '@vitejs/plugin-react'
import { defineConfig } from 'vite'

// https://vite.dev/config/
export default defineConfig({
  plugins: [react()],
  root: './',  // Explicitly set root to current directory
  server: {
    proxy: {
      "/api": {
        target: "http://localhost:5037",
        changeOrigin: true,
        secure: false
      }
    }
  }
})
