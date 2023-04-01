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
            <tr v-for="(o,i) of orderListRef" :key="o.id">
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
        <button id="add"  @click="add">添加</button>
        <Parameter/>
    </main>
</Layout>
</template>

<script setup lang="ts">

import Layout from "./Layout.vue";
import "css.gg/icons/all.css"
import {reactive, ref} from "vue";
import {defineStore} from "pinia";
import {useStore, OrderType} from "../store";
import Parameter from "./Parameter.vue";

const orderListRef=ref<OrderType[]>([]);

function prioritize(i:number){
    let orderList=orderListRef.value;
    if(i>=0&&i<orderList.length){
        orderList.unshift(orderList.splice(i,1)[0]);
    }
}
function remove(i:number){
    let orderList=orderListRef.value;
    if(i>=0&&i<orderList.length){
        orderList.splice(i,1);
    }
}

function add(){
    const store=useStore();
    store.newOrder.id=store.nextId++;
    orderListRef.value.push({ ... store.newOrder});
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
#add{
    margin: 1em;
    width: 20em;
    height: 3em;
}
</style>
