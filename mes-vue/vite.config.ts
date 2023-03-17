import { defineConfig } from 'vite'
import vue from '@vitejs/plugin-vue'

// https://vitejs.dev/config/
export default defineConfig({
  plugins: [vue()],
  server:{
    proxy:{
      '/api/Plc':{
        target:'http://localhost:5121',
        changeOrigin:true,
        secure:false,
      }
    }
  }
})
