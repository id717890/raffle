<template>
<b-row class="mt-5 pt-3 w-100">
  <b-col lg=2 md=3 sm=12>
    <b-nav vertical pills>
      <b-nav-item to="/dashboard/gifts">Призы и ключи</b-nav-item>
      <b-nav-item to="/dashboard/settings">Настройки</b-nav-item>
      <b-nav-item to="/dashboard/other">Прочее</b-nav-item>
    </b-nav>
  </b-col>
  <b-col lg=10 md=9 sm=12>
    <router-view></router-view>
  </b-col>
</b-row>
</template>
