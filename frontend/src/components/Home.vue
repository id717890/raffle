<template>
  <b-container fluid class="p-0 m-0" style="height: 100%">
        <div class="prlxblock2 prlx d-flex flex-row justify-content-around align-items-center" >
          <div class="face" style="background-color: transparent">
            <h1>ПОДАРКИ</h1><br>
            <h2>и</h2><br>
            <h1>ПРИЗЫ</h1>
          </div>
          <div class="gift-block">
            <div class="bordered">
            <h2>Голосуй и выбирай призы и подарки</h2>
            <h2>Участвуй и выигрывай</h2>
            <h2>Участвуй и выигрывай</h2>
            </div>
          </div>
          
        </div>
        <!-- <div class="prblock1 prlx"></div> -->
        <div class="txt">
          <h3 style="text-align:center;">Parallax Demo</h3>
          <p>Parallax scrolling is a web site trend where the background content is moved at a different speed than the foreground content while scrolling. Nascetur per nec posuere turpis, lectus nec libero turpis nunc at, sed posuere mollis ullamcorper libero ante lectus, blandit pellentesque a, magna turpis est sapien duis blandit dignissim. Viverra interdum mi magna mi, morbi sociis. Condimentum dui ipsum consequat morbi, curabitur aliquam pede, nullam vitae eu placerat eget et vehicula. Varius quisque non molestie dolor, nunc nisl dapibus vestibulum at, sodales tincidunt mauris ullamcorper, dapibus pulvinar, in in neque risus odio. Accumsan fringilla vulputate at quibusdam sociis eleifend, aenean maecenas vulputate, non id vehicula lorem mattis, ratione interdum sociis ornare. Suscipit proin magna cras vel, non sit platea sit, maecenas ante augue etiam maecenas, porta porttitor placerat leo.</p>
        </div>
        <div class="prlxblock1 prlx d-flex justify-content-center" align-v="center">
          <div class="steps-wrapper">
            <div class="step">
              <span class="number">1</span>
              <span>Выбираешь подарок и делаешь взнос</span>
            </div>
            <div class="step">
              <span class="number odd">2</span>
              <span>Получаешь уникальные ключи от 1 до нескольких. Чем больше ключей тем больше твой шанс</span>
            </div>
            <div class="step">
              <span class="number">3</span>
              <span>Ждешь когда накопиться полная стоимость выбранного подарка</span>
            </div>
            <div class="step">
              <span class="number odd">4</span>
              <span>Участвуешь в розыгрыше выбранного подарка</span>
            </div>
            <div class="step">
              <span class="number">5</span>
              <span>Получаешь подарок</span>
            </div>
          </div>
        </div>
        <div class="txt">
          <b-container fluid>
            <b-row>
              <b-col class="d-flex justify-content-center" style="flex-flow:row wrap; align-items: center">
                <b-card :title="gift.gift.name" class="m-4 p-4" v-for="gift in this.getGiftsDraw" :key="gift.id"
                  :img-src="gift.gift.image" style="max-width: 20rem; border: none" img-top
                >
                <p class="card-text">{{gift.info}}</p>
                <p class="card-text">Собрано: {{Number((gift.reached * 100 / gift.price).toFixed(1))}}%</p>
                <p class="card-text">Участников: {{Number((gift.reached / gift.priceKey).toFixed(0))}}</p>
                </b-card>
              </b-col>
            </b-row>
          </b-container>
        </div>
        <div class="prblock3 prlx"></div>
  </b-container>
</template>

<script>
import {mapGetters} from 'vuex'

export default {
  computed: {
    ...mapGetters(['getGiftsDraw'])
  },
  async created () {
    this.$store.dispatch('getGiftsDraw')
  }
}
</script>
