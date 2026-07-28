import { defineConfig } from 'vite'
import react from '@vitejs/plugin-react'
import tailwindcss from '@tailwindcss/vite'

export default defineConfig({
  plugins: [react(), tailwindcss(),],
  server: {
    host: true, // same as --host flag
    watch: {
      usePolling: true, // <-- fixes file-watching issue in Docker
      interval: 100 // check every 100ms (adjust if needed)
    }
  }
})