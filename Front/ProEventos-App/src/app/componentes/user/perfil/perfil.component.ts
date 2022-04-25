import { Component, OnInit } from '@angular/core';
import { AbstractControlOptions, FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ValidatorField } from '@app/helpers/ValidatorField';

@Component({
  selector: 'app-perfil',
  templateUrl: './perfil.component.html',
  styleUrls: ['./perfil.component.scss']
})
export class PerfilComponent implements OnInit {

  form!: FormGroup;

  constructor(public fb : FormBuilder) { }

  get f() : any {return this.form.controls;}

  onSubmit():void{
    //Vai parar aqui se estiver inválido
    if(this.form.invalid) {
      return;
    }
  }

  public resetForm(event: any): void {
    event.preventDefault();
    this.form.reset();
  }

  ngOnInit() {
    this.validation();
  }

  private validation(): void {

    const formOptions: AbstractControlOptions = {
      validators: ValidatorField.MustMatch('senha', 'confirmarSenha')
    };

    this.form = this.fb.group({
      titulo: ['', Validators.required ],
      primeiroNome: ['', Validators.required ],
      ultimoNome: ['', Validators.required],
      email: ['', [Validators.required, Validators.email]],
      telefone: ['', [Validators.required]],
      descricao: ['', [Validators.required, Validators.maxLength(200)]],
      funcao: ['', Validators.required],
      senha: ['', [Validators.required, Validators.minLength(8),]],
      confirmarSenha: ['', Validators.required ],
    },formOptions);
  }

}
