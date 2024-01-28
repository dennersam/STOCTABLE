import { Component, EventEmitter, Input, Output, forwardRef } from '@angular/core';
import { ControlValueAccessor, NG_VALUE_ACCESSOR } from '@angular/forms';
import { Unidade } from 'src/app/estoque/enum/Unidade';

const INPUT_FIELD_VALUE_ACCESSOR: any = {
  provide: NG_VALUE_ACCESSOR,
  useExisting: forwardRef(() => StInputComponent),
  multi: true
}

@Component({
  selector: 'st-input',
  templateUrl: './st-input.component.html',
  styleUrls: ['./st-input.component.scss'],
  providers: [INPUT_FIELD_VALUE_ACCESSOR]
})
export class StInputComponent implements ControlValueAccessor{
  @Input() classeCSS?: string;
  @Input() type?: string;
  @Input() id?: string;
  @Input() label?: string;
  @Input() control?: string;
  @Input() isReadOnly = false;
  @Input() placeholder = '';
  @Input() hasLabel? = true;


  @Input() options: any[] = [];
  @Input() selectedOption: any;
  @Output() optionSelected = new EventEmitter<any>();

  private innerValue: any;

  get value(){
    return this.innerValue;
  }

  set value(v: any){
     if(v != this.innerValue){
      this.innerValue = v;
      this.onChangeCb(v);

     }
  }

  constructor(){}

  onChangeCb: (_: any) => void = () => {};
  onTouchedCb: (_: any) => void = () => {};

  writeValue(v: any): void {
    this.value = v;
  }
  registerOnChange(fn: any): void {
    this.onChangeCb = fn;
  }
  registerOnTouched(fn: any): void {
    this.onTouchedCb = fn;
  }
  setDisabledState?(isDisabled: boolean): void {
    this.isReadOnly = isDisabled;
  }

  onOptionSelected(option: any) {
    this.selectedOption = option;
    this.optionSelected.emit(option);
  }

}
