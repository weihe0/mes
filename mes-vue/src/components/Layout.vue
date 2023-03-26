<template>
  <div>
    <nav>
      <ul>
        <router-link to="/"><li>订单管理</li></router-link>
        <router-link to="/device"><li>设备管理</li></router-link>
      </ul>
    </nav>
    <slot></slot>
  </div>

</template>

<script setup lang="ts">
</script>

<style scoped>
div{
  display: flex;
  height: 100%;
}
nav{
  display: block;
  background-color: deepskyblue;
  height: 100%;
  flex: none;
}
ul{
  list-style-type: none;
  padding: 2em 2em;
  margin: 0;
}
li{
  margin: 1em 0;
  width: 10em;
  text-align: center;
  color: white;
  font-family: sans-serif;
}
</style>
