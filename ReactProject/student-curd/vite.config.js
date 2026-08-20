import { defineConfig } from 'vite'
import react from '@vitejs/plugin-react'

// https://vite.dev/config/
export default defineConfig({
  plugins: [react(),],
  server: {
    host: true, // same as --host flag
    watch: {
      usePolling: true, // <-- fixes file-watching issue in Docker
      interval: 100 // check every 100ms (adjust if needed)
    }
  }
})
