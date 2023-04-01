import { createApp } from 'vue'
import App from './App.vue'
import {createRouter, createWebHashHistory} from 'vue-router'
import {createPinia} from "pinia";
import Order from "./components/Order.vue";
import Device from "./components/Device.vue";
import Signin from "./components/Signin.vue"
import Parameter from "./components/Parameter.vue";
const router=createRouter({
    history:createWebHashHistory(),
    routes:[
        {path:'/device', component: Device},
        {path:'/signin', component:Signin},
        {path:'/',component:Order},
        {path:'/order/parameter',component:Parameter},
    ]
})
const pinia=createPinia();
createApp(App).use(pinia).use(router).mount('#app');
