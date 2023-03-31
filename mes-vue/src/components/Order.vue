<template>
<Layout>
    <main>
        <table>
            <thead><tr>
                <td>订单号</td>
                <td>数量</td>
                <td>颜色</td>
                <td>产量</td>
                <td>位置</td>
                <td>动作</td>
            </tr></thead>
            <tbody>
            <tr v-for="(o,i) of order_list_ref" :key="o.id">
                <td>{{o.id}}</td>
                <td>{{o.dosage}}</td>
                <td>{{o.color}}</td>
                <td>{{o.production}}</td>
                <td>{{o.position}}</td>
                <td><button @click="prioritize(i)"><i class="gg-arrow-up"></i></button>
                <button @click="remove(i)"><i class="gg-remove"></i> </button>
                </td>
            </tr>
            </tbody>
        </table>
        <router-link to="parameter"><button>添加</button></router-link>
    </main>
</Layout>
</template>

<script setup lang="ts">

import Layout from "./Layout.vue";
import "css.gg/icons/all.css"
import {ref} from "vue";
type OrderType={
    id:number,
    dosage:number,
    color:string,
    production:number,
    position:number,
};
const order_list_ref=ref<OrderType[]>([]);
const length=5;
const random_array= new Uint8Array(length * 4);
crypto.getRandomValues(random_array);
for(let i=0;i<5;i++){
    let o:OrderType={
      id:random_array[4*i],
        color:"红色",
        dosage:random_array[4*i+1],
        production:random_array[4*i+2],
        position:random_array[4*i+3]%4+1,
    };
    order_list_ref.value.push(o);
}
function prioritize(i:number){
    let order_list=order_list_ref.value;
    if(i>=0&&i<order_list.length){
        order_list.unshift(order_list.splice(i,1)[0]);
    }
}
function remove(i:number){
    let order_list=order_list_ref.value;
    if(i>=0&&i<order_list.length){
        order_list.splice(i,1);
    }
}
</script>

<style scoped>
main{
    display: flex;
    flex-direction: column;
    justify-content: center;
    align-items: center;
}
table{
    border-collapse: collapse;
    box-shadow: gray;
}
td{
    min-width: 4em;
}
thead{
    border-top: solid black 1px;
}
tbody tr{
    border-top: solid black 1px;
}
tbody:last-child{
    border-bottom: solid black 1px;
}
</style>
