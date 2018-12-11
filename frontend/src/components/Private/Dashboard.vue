<template>
<b-row class="w-100 p-0 m-0">
  <b-col lg=2 md=3 sm=12 class="mt-5 pt-3 ">
    <b-nav vertical>
      <b-nav-item to="/dashboard/gifts">Призы и ключи</b-nav-item>
      <b-nav-item to="/dashboard/settings">Настройки</b-nav-item>
      <b-nav-item to="/dashboard/other">Прочее</b-nav-item>
    </b-nav>
  </b-col>
  <b-col lg=10 md=9 sm=12 class="mt-5 pt-3">
    <router-view></router-view>
  </b-col>
</b-row>
</template>
