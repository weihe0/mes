import { defineConfig } from 'vite'
import vue from '@vitejs/plugin-vue'

// https://vitejs.dev/config/
export default defineConfig({
  plugins: [vue()],
  server:{
    proxy:{
      '/api/hub':{
        target:'http://localhost:5069',
        changeOrigin:true,
        ws:true,
      },
      '/WeatherForecast':{
        target:'http://localhost:5069',
        changeOrigin:true,
      },
      '/api/Plc':{
        target:'http://localhost:5069',
        changeOrigin:true,
        secure:false,
      }
    }
  }
})
