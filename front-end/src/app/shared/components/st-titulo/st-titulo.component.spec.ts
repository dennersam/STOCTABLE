import { ComponentFixture, TestBed } from '@angular/core/testing';

import { StTituloComponent } from './st-titulo.component';

describe('StTituloComponent', () => {
  let component: StTituloComponent;
  let fixture: ComponentFixture<StTituloComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ StTituloComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(StTituloComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
