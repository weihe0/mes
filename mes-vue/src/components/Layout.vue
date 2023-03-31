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
    display: grid;
    grid-template-columns: 1fr 4fr;
}
@media screen and (max-width: 50rem) {
    div{
        display: block;
    }
    nav{
        display: none;
    }
}
</style>
