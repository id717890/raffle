<template>
<b-container>
    <b-row align-h="center">
      <b-col lg=5 md=7 sm=12 xs=12 class="pt-10">
        <b-card class="p-3 text-dark">
          <h3 class="mb-4">Create new password</h3>
          <!-- <div class="mt-2" v-if="this.getMessages !== null">
            <b-alert show variant="success" v-for="(message, index) in this.getMessages" :key="index">{{message}}</b-alert>
          </div> -->
          <div class="mt-2" v-if="this.getOtherErrors !== null">
            <div v-for="(error, index) in this.getOtherErrors" :key="index">
              <b-alert show variant="danger" v-for="(message, indexMessage) in error" :key="indexMessage">{{message}}</b-alert>
            </div>
          </div>
          <!-- <div class="mt-2" v-if="this.getErrors !== null">
            <b-alert show variant="danger" v-for="(error, index) in this.getOtherErrors" :key="index">{{error}}</b-alert>
          </div> -->
          <b-form @submit="onSubmit">
            <b-form-group id="passwordGroup" label="New password:" label-for="password">
              <b-form-input id="password" type="password" v-model="form.password" required placeholder="Enter new password"></b-form-input>
              <div class="mt-2" v-if="this.getErrors !== null && this.getErrors.Password !=null">
                <b-alert class="p-0" show variant="danger" v-for="(error, index) in this.getErrors.Password" :key="index">{{error}}</b-alert>
              </div>
            </b-form-group>
            <b-form-group id="passwprdConfirmGroup" label="New password confirm:" label-for="passwordConfirm">
              <b-form-input id="passwordConfirm" type="password" v-model="form.passwordConfirm" required placeholder="Enter new password again"></b-form-input>
              <div class="mt-2" v-if="this.getErrors !== null && this.getErrors.PasswordConfirm !=null">
                <b-alert class="p-0" show variant="danger" v-for="(error, index) in this.getErrors.PasswordConfirm" :key="index">{{error}}</b-alert>
              </div>
            </b-form-group>
            <fieldset >
            <div class="d-flex ">
                <b-button :disabled="!validated" type="submit" variant="success" class="w-100">OK</b-button>
            </div>
            </fieldset>
          </b-form>
        </b-card>
      </b-col>
    </b-row>
  </b-container>
</template>

<script>
import {mapActions, mapGetters} from 'vuex'

export default {
  data () {
    return {
      form: {
        userId: '',
        code: '',
        password: 'qweqwe',
        passwordConfirm: 'qweqwe'
      }
    }
  },
  computed: {
    ...mapGetters(['getMessages', 'getErrors']),
    getOtherErrors () {
      let newObject = {}
      const fields = ['Password', 'PasswordConfirm']
      for (let prop in this.getErrors) {
        if (!fields.includes(prop)) newObject[prop] = this.getErrors[prop]
      }
      return newObject
    },
    validated () {
      return this.form.password === this.form.passwordConfirm && this.form.password.length >= 6
    }
  },
  methods: {
    ...mapActions(['resetPasswordVerifyToken']),
    resetForm () {
      this.form.password = ''
      this.form.passwordConfirm = ''
      this.form.userId = ''
      this.form.code = ''
    },
    onSubmit (evt) {
      evt.preventDefault()
      this.resetPasswordVerifyToken(this.form)
        .then((x) => {
          // this.resetForm()
          this.$router.push('Message')
        })
        .catch(x => {
        })
    }
  },
  async created () {
    this.$store.dispatch('clearAllMessages')
    let id = this.$route.query.id
    let code = this.$route.query.code
    // console.log(id)
    // console.log(code)
    if (id === null || code === null || id === '' || code === '') alert('Некорректная ссылка для восстановления')
    else {
      this.form.userId = id
      this.form.code = code
    }
  }
}
</script>
