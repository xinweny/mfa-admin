from typing import TypeVar, Generic
from pydantic import BaseModel

from app.core.pagination import PaginationMetadata

T = TypeVar('T', bound=BaseModel)

class ApiResponseMetadata(BaseModel):
    pagination: PaginationMetadata | None

class ApiResponse(BaseModel, Generic[T]):
    data: T | tuple[T] | None = None
    metadata: ApiResponseMetadata | None = None