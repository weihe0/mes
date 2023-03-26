<template>
<Layout>
      <form class="plc" @submit.prevent="">
        <div class="item">
          <label>X轴自动速度</label><input type="range" min="10" max="60" step="5" v-model="plc_parameter.speed_x"/>
          <span>{{ plc_parameter.speed_x }}</span>
        </div>
        <div>
          <label>Z轴自动速度</label><input type="range" min="10" max="60" step="5" v-model="plc_parameter.speed_z"/>
          <span>{{ plc_parameter.speed_z }}</span>
        </div>
        <div>
          <label>传送带自动速度</label><input type="range" min="2" max="5" step="1" v-model="plc_parameter.speed_conveyor"/>
          <span>{{ plc_parameter.speed_conveyor }}</span>
        </div>
        <div>
          <label>步进电机自动速度</label><input type="range" min="2" max="5" step="1" v-model="plc_parameter.speed_stepper"/>
          <span>{{ plc_parameter.speed_stepper }}</span>
        </div>
        <button @click="plc_start" :disabled="disabled">启动</button>
        <button @click="plc_clear">停止</button>
      </form>
      <table>
        <thead>
        <tr><td>数据</td><td>值</td></tr>
        </thead>
        <tbody>
        <tr><td>X坐标</td><td>{{ plc_state.x }}</td></tr>
        <tr><td>Z坐标</td><td>{{ plc_state.z }}</td></tr>
        <tr v-for="(w,i) of plc_state.weights">
          <td>重量{{i+1}}</td><td>{{w}}</td>
        </tr>
        </tbody>
      </table>
</Layout>
</template>

<style scoped>
form.plc {
  width: 20em;
  display: flex;
  flex-direction: column;
  border: black solid 1pt;
  border-radius: 2em;
  padding: 2em;
}

form div {
  display: flex;
  align-items: center;
}

form button {
  margin: 0.5em;
}

div label {
  margin: 1em;
}

div input {
  margin: 1em;
}

thead tr{
  background-color: #005BBB;
}
tbody tr:nth-child(2n+1){
  background-color: #FFD500;
}
tbody tr:nth-child(2n){
  background-color: #005BBB;
}
td{
  width: 10em;
  text-align: center;
}
button{
  background-color: green;
  height: 3em;
  border-radius: 10px;
  border: green;
}
div label{
  background-color: #005BBB;
}
</style>

<script setup lang="ts">
import Layout from "./Layout.vue";
import {ref,reactive} from "vue";
let disabled=ref(true);
let plc_parameter=reactive({
  speed_x:10,
  speed_z:10,
  speed_conveyor:2,
  speed_stepper:5,
})
let plc_state=reactive({
  stopped:false,
  x:0.0,
  z:0.0,
  weights:[0,0,0,0],
})
let timer: number | null = null;

async function plc_start() {
  if (!timer) {
    await fetch('/api/Plc/start',
        {
          method: 'POST', headers: {'Content-Type': 'application/json'},
          body: JSON.stringify({
            speed_x:plc_parameter.speed_x,
            speed_z:plc_parameter.speed_z,
            speed_conveyor:plc_parameter.speed_conveyor,
            speed_stepper:plc_parameter.speed_stepper,
          })
        });
    timer = setInterval(async () => {
      plc_state = await (await fetch('/api/Plc')).json();
      if(plc_state.stopped){
        if (timer) {
          clearInterval(timer);
          timer = null;
        }
      }
    }, 1000);
  }
}

function plc_clear() {
  if (timer) {
    clearInterval(timer);
    timer = null;
  }
  fetch('/api/Plc/stop', {
    method: 'POST', headers: {'Content-Type': 'application/json'},
  });
}
</script>
