<template>
  <b-container>
      <b-tabs>
        <b-tab title="Активные">
          <table class="table hover stripped ">
            <tbody>
              <tr v-for="row in getGiftsDrawByUserActive" :key="row.id">
                <td>{{row.giftName}}</td>
                <td>{{row.giftName}}</td>
              </tr>
            </tbody>
          </table>
          
        </b-tab>
        <b-tab title="Завершённые">
          <table class="table hover stripped ">
            <tbody>
              <tr v-for="row in getGiftsDrawByUserNotActive" :key="row.id">
                <td>{{row.giftName}}</td>
                <td>{{row.giftName}}</td>
              </tr>
            </tbody>
          </table>
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
