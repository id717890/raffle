<template>
<b-container>
  <b-row>
    <b-col lg=6 md=10 sm=12 xs=12 offset-lg=3 offset-md=1  class="pt-10">
      <b-card class="card-pay" :title="gift.giftName"
        :img-src="gift.image"
      >
        <b-card-body>
          <p class="card-text">
            {{gift.giftDescription}}
          </p>
        </b-card-body>
        <b-card-body>
          <p>Собрано</p>

        </b-card-body>
      </b-card>
    </b-col>
  </b-row>
</b-container>
</template>

<script>
import {mapGetters} from 'vuex'

export default {
  data () {
    return {
      idd: 0
    }
  },
  computed: {
    ...mapGetters(['getGiftDrawById']),
    gift () {
      return this.getGiftDrawById(this.$route.params.id)
    }
  }
}
</script>

<style>

</style>
