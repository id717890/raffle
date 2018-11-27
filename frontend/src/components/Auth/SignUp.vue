<template>
  <b-container>
    <b-row align-h="center" class="mt-5">
      <b-col cols="5">
        <b-card class="p-3">
          <h3 class="mb-4">Account registration</h3>
          <div class="mt-2" v-if="this.getMessages !== null">
            <b-alert show variant="success" v-for="(message, index) in this.getMessages" :key="index">{{message}}</b-alert>
          </div>
          <div class="mt-2" v-if="this.getErrors !== null">
            <b-alert show variant="danger" v-for="(error, index) in this.getOtherErrors" :key="index">{{error}}</b-alert>
          </div>
          <b-form @submit="onSubmit">
            <b-form-group id="emailGroup" label="Email address:" label-for="email">
              <b-form-input id="email" type="email" v-model="form.email" required placeholder="Enter email"></b-form-input>
              <div class="mt-2" v-if="this.getErrors !== null && this.getErrors.Email !=null">
                <b-alert class="p-0" show variant="danger" v-for="(error, index) in this.getErrors.Email" :key="index">{{error}}</b-alert>
              </div>
            </b-form-group>
            <b-form-group id="passwordGroup" label="Password:" label-for="password">
              <b-form-input id="password" type="password" v-model="form.password" required placeholder="Enter password"></b-form-input>
              <div class="mt-2" v-if="this.getErrors !== null && this.getErrors.Password !=null">
                <b-alert class="p-0" show variant="danger" v-for="(error, index) in this.getErrors.Password" :key="index">{{error}}</b-alert>
              </div>
            </b-form-group>
            <b-form-group id="passwprdConfirmGroup" label="Password Confirm:" label-for="passwordConfirm">
              <b-form-input id="passwordConfirm" type="password" v-model="form.passwordConfirm" required placeholder="Enter password"></b-form-input>
              <div class="mt-2" v-if="this.getErrors !== null && this.getErrors.PasswordConfirm !=null">
                <b-alert class="p-0" show variant="danger" v-for="(error, index) in this.getErrors.PasswordConfirm" :key="index">{{error}}</b-alert>
              </div>
            </b-form-group>
            <b-form-group id="firstNameGroup" label="First Name:" label-for="firstName">
              <b-form-input id="firstName" type="text" v-model="form.firstName" required placeholder="Enter first name"></b-form-input>
              <div class="mt-2" v-if="this.getErrors !== null && this.getErrors.FirstName !=null">
                <b-alert class="p-0" show variant="danger" v-for="(error, index) in this.getErrors.FirstName" :key="index">{{error}}</b-alert>
              </div>
            </b-form-group>
            <b-form-group id="lastNameGroup" label="Last Name:" label-for="lastName">
              <b-form-input id="lastName" type="text" v-model="form.lastName" required placeholder="Enter last name"></b-form-input>
              <div class="mt-2" v-if="this.getErrors !== null && this.getErrors.LastName !=null">
                <b-alert class="p-0" show variant="danger" v-for="(error, index) in this.getErrors.LastName" :key="index">{{error}}</b-alert>
              </div>
            </b-form-group>
            <fieldset >
            <div class="d-flex ">
                <b-button :disabled="!validated" type="submit" variant="success" class="w-100">Register</b-button>
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
      showDismissibleAlert: false,
      form: {
        email: 'jusupovz@gmail.com',
        password: 'qweqwe',
        passwordConfirm: 'qweqwe',
        firstName: 'qweqwe',
        lastName: 'qweqwe'
      }
    }
  },
  computed: {
    ...mapGetters(['getErrors', 'getMessages']),
    getOtherErrors () {
      // console.log(this.getErrors)
      let newObject = {}
      const fields = ['Email', 'Password']
      for (let prop in this.getErrors) {
        if (!fields.includes(prop)) newObject[prop] = this.getErrors[prop]
      }
      return newObject
    },
    validated () {
      return this.form.password === this.form.passwordConfirm && this.form.password.length >= 6
    }
  },
  // created () {
  //   if (this.getErrors !== null && this.getErrors.Email !== undefined) {
  //     console.log('mount')
  //     console.log(this.getErrors)
  //   }
  // },
  created () {
    this.$store.dispatch('clearAllMessages')
    // console.log(this.getOtherErrors)
  },
  methods: {
    ...mapActions(['signUserUp']),
    handleClick () {
      this.showDismissibleAlert = true
    },
    resetForm () {
      this.form.email = ''
      this.form.password = ''
      this.form.passwordConfirm = ''
      this.form.firstName = ''
      this.form.lastName = ''
    },
    onSubmit (evt) {
      evt.preventDefault()
      // alert(JSON.stringify(this.form))
      this.signUserUp(this.form)
        .then((x) => {
          this.resetForm()
          // console.log('view')
          // console.log(x)
          // this.$router.push('/')
        })
        .catch(x => {
          // console.log('view catch')
          // console.log(x)
          // todo show errors from vuex state
        })
    }
  }
}
</script>

