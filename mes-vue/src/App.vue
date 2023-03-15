<template>
  <main>
    <form class="plc" @submit.prevent="">
      <div class="item">
        <label>参数1</label><input type="range" min="0" max="5" step="0.1" v-model="a"/><span>{{ a }}</span>
      </div>
      <div>
        <label>参数2</label><input type="range" min="0" max="5" step="0.1" v-model="b"/><span>{{ b }}</span>
      </div>
      <div>
        <label>参数3</label><input type="range" min="0" max="5" step="0.1" v-model="c"/><span>{{ c }}</span>
      </div>
      <div>
        <label>参数4</label><input type="range" min="0" max="5" step="0.1" v-model="d"/><span>{{ d }}</span>
      </div>
      <button @click="plc_start">启动</button>
      <button @click="plc_clear">停止</button>
    </form>
    <div class="plc_state">
      <div>
        <label>X坐标</label><span>{{ x }}</span>
      </div>
      <div>
        <label>Y坐标</label><span>{{ z }}</span>
      </div>
    </div>
  </main>

</template>

<style>
html, body, #app {
  width: 100%;
  height: 100%;
  display: flex;
  justify-content: center;
  align-items: center;
}
main{
  display: flex;
  justify-content: space-around;
  width: 100%;
}
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
</style>

<script setup lang="ts">
import {ref} from "vue";
import {HubConnection, HubConnectionBuilder} from '@microsoft/signalr'

let a = ref(0.0);
let b = ref(0.0);
let c = ref(0.0);
let d = ref(0.0);
let x = ref(0.0);
let z = ref(0.0);
let weather = ref('0');
const connection = new HubConnectionBuilder().withUrl('/api/plc').build();

let timer: number | null = null;

async function plc_start() {
  if (!timer) {
    await fetch('/api/Plc/start',
        {
          method: 'POST', headers: {'Content-Type': 'application/json'},
          body: JSON.stringify({a: 0, b: 0, c: 0, d: 0})
        });
    timer = setInterval(async () => {
      let plc_state: { x: number, z: number } = await (await fetch('/api/Plc')).json();
      x.value = plc_state.x;
      z.value = plc_state.z;
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
  x.value = z.value = 0;
}
</script>
