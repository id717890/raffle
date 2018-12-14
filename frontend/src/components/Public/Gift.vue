<template>
<b-container>
  <b-row>
    <b-col lg=6 md=10 sm=12 xs=12 offset-lg=3 offset-md=1  class="pt-10">
      <b-card v-if="gift !== undefined && gift !== null" class="card-pay mb-5" :title="gift.giftName"
        :img-src="gift.imageLocal !== null ? gift.imageLocal : gift.image" 
      >
        <b-card-body>
          <p class="card-text">
            {{gift.giftDescription}}
          </p>
        </b-card-body>
        <b-card-body>
          <p>Собрано: {{Number(gift.reached * 100 / gift.price).toFixed(1)}}%</p>
            <b-progress class="mt-1" :max="gift.price" :value="gift.reached" variant="success" animated></b-progress>
        </b-card-body>
        <b-card-body class="m-0 pt-0 pb-0">
          <b-alert show variant="primary">Цена 1 ключа - {{gift.priceKey}} руб.</b-alert>          
        </b-card-body>
        <b-card-body v-if="isAuth">
          <b-row>
            <b-col>
              <b-form-group id="sumInputGroup" label="Кол-во ключей" label-for="sum">
                <b-form-input id="sum" type="number" min="0" v-model="countKeys" required placeholder="Введите кол-во ключей"></b-form-input>
              </b-form-group>
            </b-col>
            <b-col class="justify-content-center align-items-center">
              <b-form-group id="sumInputGroup" label="&nbsp;" label-for="sum">
                <div>
                  <form target="_blank" method="POST" action="https://money.yandex.ru/quickpay/confirm.xml">
                    <!--Номер кошелька в системе Яндекс Денег-->
                    <input type="hidden" name="receiver" :value="yandex.receiver">
                    
                    <!--Название платежа, я не нашел, где этот параметр используется, поэтому просто указал адрес своего сайта (длина 50 символов)-->
                    <input type="hidden" name="formcomment" :value="payData.formcomment">
                    
                    <!--Этот параметр передаёт ID плагина, для того, чтобы скрипту было понятно, что потом отсылать пользователю (длина 64 символа)-->
                    <input type="hidden" name="label" :value="payData.label">
                    
                    <!--Тип формы, может принимать значения shop (универсальное), donate (благотворительная), small (кнопка)-->
                    <input type="hidden" name="quickpay-form" :value="yandex.quickpayForm">
                    
                    <!--Назначение платежа, это покупатель видит на сайте Яндекс Денег при вводе платежного пароля (длина 150 символов)-->
                    <input type="hidden" name="targets" :value="payData.targets">
                    
                    <!--Сумма платежа, валюта - рубли по умолчанию-->
                    <input type="hidden" name="sum" :value="totalSum" data-type="number">
                    
                    <!--Должен ли Яндекс запрашивать ФИО покупателя-->
                    <input type="hidden" name="need-fio" :value="yandex.needFio">
                    
                    <!--Должен ли Яндекс запрашивать email покупателя-->
                    <input type="hidden" name="need-email" :value="yandex.needEmail">
                    
                    <!--Должен ли Яндекс запрашивать телефон покупателя-->
                    <input type="hidden" name="need-phone" :value="yandex.needPhone">
                    
                    <!--Должен ли Яндекс запрашивать адрес покупателя-->
                    <input type="hidden" name="need-address" :value="yandex.needAddress">
                    
                    <!--Метод оплаты, PC - Яндекс Деньги, AC - банковская карта-->
                    <input type="hidden" name="paymentType" :value="payData.paymentType" />
                    
                    <!--Куда перенаправлять пользователя после успешной оплаты платежа-->
                    <input type="hidden" name="successURL" :value="yandex.successURL">
                    <button :disabled="!validCount"  class="btn btn-primary w-100">Donate</button>
                  </form>
                </div>
              </b-form-group>
            </b-col>
          </b-row>      
          <b-row>
            <b-col>
              <b-form-group >
                <b-form-radio-group id="radios2" v-model="payData.paymentType" name="radioSubComponent">
                  <b-form-radio value="AC" checked>Карта</b-form-radio>
                  <b-form-radio value="PC">Яндекс.Кошелёк</b-form-radio>
                  <b-form-radio value="MC">SMS</b-form-radio>
                </b-form-radio-group>
              </b-form-group>
            </b-col>
          </b-row>    
          <b-alert class="mb-0" show variant="danger">Сумма к оплате - {{totalSum}} руб.</b-alert>
        </b-card-body>
        <b-card-body v-else>
          <b-alert show class="bg-warning" variant="warning">
            Для приобретения ключен нужно авторизоваться!
          </b-alert>
        </b-card-body>
      </b-card>
    </b-col>
  </b-row>
</b-container>
</template>

<script>
import {mapGetters, mapState} from 'vuex'
import axios from 'axios'

export default {
  data () {
    return {
      sum: 0,
      countKeys: 1,
      payData: {
        formcomment: '',
        label: '',
        targets: '',
        paymentType: 'AC'
      }
    }
  },
  computed: {
    ...mapState({
      yandex: state => state.payment.yandex
    }),
    ...mapGetters(['getGiftDrawById', 'isAuth', 'getUser']),
    gift () {
      return this.getGiftDrawById(this.$route.params.id)
    },
    validCount () {
      return this.countKeys !== null && this.countKeys !== '' && this.countKeys > 0
    },
    totalSum () {
      if (this.gift !== undefined && this.gift !== null) {
        if (this.countKeys !== null && this.countKeys > 0) {
          return Math.floor(this.countKeys * this.gift.priceKey)
        }
      }
      return 0
    }
    // countOfKeys () {
    //   if (this.sum !== null && this.sum > 0) {
    //     return Math.floor(this.sum / this.gift.priceKey)
    //   }
    //   return 0
    // }
  },
  methods: {
    donate () {
      // let headers = {
      //   'Content-Type': 'application/xml'
      // }
      let form = new FormData()
      form.set('receiver', '410016208060232')
      // form.formcomment = 'test'
      // form.label = 'test label'
      // form.quickpay_form = 'shop'
      // form.targets = 'test label'
      // form.sum = 2
      // form.paymentType = 'AC'

      axios({
        method: 'post',
        url: 'https://money.yandex.ru/quickpay/confirm.xml',
        data: form,
        config: {headers: { 'Content-Type': 'application/xml' }}
      })
        .then(function (response) {
          console.log(response)
        })
        .catch(function (response) {
          console.log(response)
        })

      // axios.get('https://money.yandex.ru/quickpay/confirm.xml', form, {headers: headers})
      //   .then(x => console.log(x.response.data))
      //   .catch(x => console.log(x))
    }
  },
  mounted () {
    if (this.gift !== undefined && this.gift !== null) {
      this.payData.formcomment = 'Donat на получения ключа(ей) подарка №' + this.gift.id
      this.payData.label = '[' + this.getUser + '][' + this.gift.id + ']'
      this.payData.targets = 'Donate для получения ключа(ей) подарка ' + this.gift.giftName
    }
  },
  watch: {
    gift () {
      if (this.gift !== undefined && this.gift !== null) {
        this.payData.formcomment = 'Donat на получения ключа(ей) подарка №' + this.gift.id
        this.payData.label = '[' + this.getUser + '][' + this.gift.id + ']'
        this.payData.targets = 'Donate для получения ключа(ей) подарка ' + this.gift.giftName
      }
    }
  }
}
</script>

<style>

</style>
