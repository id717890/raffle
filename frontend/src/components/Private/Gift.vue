<template>
  <b-container fluid class="p-0 m-0 w-100">
      <b-tabs>
        <b-tab title="Активные" class="pt-1">
          <b-card class="p-0 m-0 w-100" no-body>
          <table class="table " style="background-color: white">
            <colgroup>
              <col style="width: 130px"/>
              <col/>
              <col style="width: 100px"/>
              <col/>
            </colgroup>
            <thead>
              <tr>
                <th></th>
                <th>Наименование</th>
                <th>Собрано</th>
                <th>Ключи</th>
              </tr>
            </thead>
            <tbody>
              <tr v-for="row in getGiftsDrawByUserActive" :key="row.id">
                <td><img :src="row.giftImage" :alt="row.giftName" style="max-width: 100px"></td>
                <td>{{row.giftName}}</td>
                <td>{{Number((row.reached * 100 / row.price).toFixed(1))}}%</td>
                <td>
                  <p v-for="key in row.keys" :key="key.id">{{key.key}}</p>

                </td>
              </tr>
            </tbody>
          </table>
          </b-card>

          
          
        </b-tab>
        <b-tab title="Завершённые" class="pt-1">
          <b-card class="p-0 m-0 w-100" no-body>
          <table class="table " style="background-color: white">
            <colgroup>
              <col style="width: 130px"/>
              <col/>
              <col style="width: 100px"/>
              <col/>
            </colgroup>
            <thead>
              <tr>
                <th></th>
                <th>Наименование</th>
                <th>Собрано</th>
                <th>Ключи</th>
              </tr>
            </thead>
            <tbody>
              <tr v-for="row in getGiftsDrawByUserNotActive" :key="row.id">
                <td><img :src="row.giftImage" :alt="row.giftName" style="max-width: 100px"></td>
                <td>{{row.giftName}}</td>
                <td>{{Number((row.reached * 100 / row.price).toFixed(1))}}%</td>
                <td>
                  <p v-for="key in row.keys" :key="key.id">{{key.key}}</p>

                </td>
              </tr>
            </tbody>
          </table>
          </b-card>
        </b-tab>

      </b-tabs>

  </b-container>
</template>

<script>
import {mapGetters} from 'vuex'
export default {
  computed: {
    ...mapGetters(['getGiftsDrawByUserActive', 'getGiftsDrawByUserNotActive'])
  },
  async created () {
    this.$store.dispatch('getGiftsDrawByUser')
  }
}
</script>

<style>

</style>
